Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports Infragistics.Win

#Region "DragDropManager class"

Public Class DragDropManager
    Implements IDisposable

#Region "Constants"

    Private Shared ReadOnly uninitializedPoint As Point = New Point(-1, -1)

    '   The numeric code for the SHIFT key (4).
    Public Shared ReadOnly numericCodeShift As Integer = 4

    '   The numeric code for the CONTROL key (8).
    Public Shared ReadOnly numericCodeControl As Integer = 8

    '   The numeric code for the ALT key (32).
    Public Shared ReadOnly numericCodeAlt As Integer = 32

    '   Defines the drag/drop effects which are supported by this class (Copy, Move)
    Public Shared ReadOnly supportedDragDropEffects As DragDropEffects = DragDropEffects.Copy Or DragDropEffects.Move

#End Region

#Region "Member variables"

    Private _lastMouseDown As Point = DragDropManager.uninitializedPoint
    Private _dragData As Object = Nothing
    Private _dragDropEffect As DragDropEffects = DragDropEffects.None
    Private _dragImageManager As DragImageManager = Nothing
    Private _dragSource As DragDropManager.IDragSource = Nothing
    Private _dropTarget As DragDropManager.IDropTarget = Nothing

#End Region

#Region "Constructors"

    ' <summary>
    ' Creates a new instance of the <see cref="DragDropManager"/> class.
    ' </summary>
    ' <param name="dragSource">The IDragSource implementation which handles drag functionality.</param>
    ' <param name="dropTarget">The IDropTarget implementation which handles drop functionality.</param>
    Public Sub New(ByVal dragSource As DragDropManager.IDragSource, ByVal dropTarget As DragDropManager.IDropTarget)
        Me.Initialize(dragSource, dropTarget)
    End Sub

    ' <summary>
    ' Creates a new instance of the <see cref="DragDropManager"/> class.
    ' </summary>
    ' <param name="dragSource">The IDragSource implementation which handles drag functionality.</param>
    Public Sub New(ByVal dragSource As DragDropManager.IDragSource)
        Me.Initialize(dragSource, Nothing)
    End Sub

    ' <summary>
    ' Creates a new instance of the <see cref="DragDropManager"/> class.
    ' </summary>
    ' <param name="dropTarget">The IDropTarget implementation which handles drop functionality.</param>
    Public Sub New(ByVal dropTarget As DragDropManager.IDropTarget)
        Me.Initialize(Nothing, dropTarget)
    End Sub

    Private Sub Initialize(ByVal dragSource As DragDropManager.IDragSource, ByVal dropTarget As DragDropManager.IDropTarget)

        If dragSource Is Nothing AndAlso dropTarget Is Nothing Then
            Throw New Exception("Cannot create an instance of the DragDropManager class without either a drag source or a drop target.")
        End If

        '	Assign the member variables to the values of their respective constructor parameters
        Me._dragSource = dragSource
        Me._dropTarget = dropTarget

        '	If this instance serves as a drop target, set the AllowDrop
        '	property of the associated control to true.
        If (Me.SupportsDrop) Then Me._dropTarget.Control.AllowDrop = True

        '	Hook events.
        Me.HookEvents(True)
    End Sub


#End Region

#Region "Properties"

    ' <summary>
    ' Returns the UltraControlBase-derived control associated with this instance.
    ' </summary>
    Public ReadOnly Property Control() As UltraControlBase
        Get
            If Not Me._dragSource Is Nothing Then Return Me._dragSource.Control
            If Not Me._dropTarget Is Nothing Then Return Me._dropTarget.Control
            Return Nothing
        End Get
    End Property

    ' <summary>
    ' Returns whether the control associated with this instance
    ' can act as a drag source.
    ' </summary>
    Public ReadOnly Property SupportsDrag() As Boolean
        Get
            Return Not Me._dragSource Is Nothing
        End Get
    End Property

    ' <summary>
    ' Returns whether the control associated with this instance
    ' can act as a drop target.
    ' </summary>
    Public ReadOnly Property SupportsDrop() As Boolean
        Get
            Return Not Me._dropTarget Is Nothing
        End Get
    End Property

#End Region

#Region "Methods"

    ' <summary>
    ' Hooks events of interest.
    ' </summary>
    ' <param name="hook">Specifies whether to hook or unhook the events.</param>
    Private Sub HookEvents(ByVal hook As Boolean)

        If hook Then
            If Me.SupportsDrag Then
                AddHandler Me._dragSource.Control.MouseDown, AddressOf Me.OnMouseDown
                AddHandler Me._dragSource.Control.MouseMove, AddressOf Me.OnMouseMove
                AddHandler Me._dragSource.Control.QueryContinueDrag, AddressOf Me.OnQueryContinueDrag
                AddHandler Me._dragSource.Control.GiveFeedback, AddressOf Me.OnGiveFeedback
            End If

            If Me.SupportsDrop Then
                AddHandler Me._dropTarget.Control.DragOver, AddressOf Me.OnDragOver
                AddHandler Me._dropTarget.Control.DragDrop, AddressOf Me.OnDragDrop
            End If
        Else
            If Me.SupportsDrag Then
                RemoveHandler Me._dragSource.Control.MouseDown, AddressOf Me.OnMouseDown
                RemoveHandler Me._dragSource.Control.MouseMove, AddressOf Me.OnMouseMove
                RemoveHandler Me._dragSource.Control.QueryContinueDrag, AddressOf Me.OnQueryContinueDrag
                RemoveHandler Me._dragSource.Control.GiveFeedback, AddressOf Me.OnGiveFeedback
            End If

            If Me.SupportsDrop Then
                RemoveHandler Me._dropTarget.Control.DragOver, AddressOf Me.OnDragOver
                RemoveHandler Me._dropTarget.Control.DragDrop, AddressOf Me.OnDragDrop
            End If
        End If

    End Sub

    ' <summary>
    ' Handles the completion of a drag operation.
    ' </summary>
    ' <param name="canceled">Specifies whether the operation was canceled.</param>
    Private Sub OnDragOperationCompleted(ByVal canceled As Boolean)

        Me._dragData = Nothing
        Me._lastMouseDown = DragDropManager.uninitializedPoint
        Cursor.Current = Cursors.Default

        If Not Me._dragImageManager Is Nothing Then Me._dragImageManager.HideDragImage()
    End Sub

#End Region

#Region "Event Handlers"

    ' <summary>
    ' Handles the MouseDown event of the associated control.
    ' This method records the location at which the left mouse button was pressed,
    ' so that the OnMouseMouse logic can determine whether a drag operation should begin.
    ' </summary>
    Private Sub OnMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)

        If e.Button = MouseButtons.Left Then

            Dim proceed As Boolean = True

            '	If the creator of this instance specified a UIElement type for
            '	hit testing, make sure the cursor in within the bounds of one
            '	before proceeding.
            Dim hitTestElementType As Type
            hitTestElementType = IIf(Not Me._dragSource Is Nothing, Me._dragSource.HitTestElementType, Nothing)
            If Not hitTestElementType Is Nothing Then

                Dim interfaceRef As IUltraControlElement = Me.Control
                Dim controlElement As ControlUIElementBase = IIf(Not interfaceRef Is Nothing, interfaceRef.MainUIElement, Nothing)
                Dim clientPos As Point = New Point(e.X, e.Y)
                Dim elementAtPoint As UIElement = IIf(Not controlElement Is Nothing, controlElement.ElementFromPoint(clientPos), Nothing)

                '	Walk up the element's ancestor chain in search of an element
                '	of the same (or derived) type as that specified by the creator
                '	of this instance.
                While Not elementAtPoint Is Nothing

                    If (elementAtPoint.GetType() Is hitTestElementType Or elementAtPoint.GetType().IsSubclassOf(hitTestElementType)) Then Exit While

                    elementAtPoint = elementAtPoint.Parent
                End While

                proceed = Not elementAtPoint Is Nothing
            End If

            If (proceed) Then Me._lastMouseDown = New Point(e.X, e.Y)
        End If

    End Sub

    ' <summary>
    ' Handles the MouseMove event of the associated control.
    ' This method compares the location at which the left mouse button was pressed,
    ' to the size of the 
    ' </summary>
    Private Sub OnMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)

        If Me._dragSource Is Nothing Then Return

        If (e.Button And MouseButtons.Left) = 0 Then Return

        Dim lastMouseDown As Point = Me._lastMouseDown
        If (lastMouseDown.X <> DragDropManager.uninitializedPoint.X AndAlso lastMouseDown.Y <> DragDropManager.uninitializedPoint.Y) Then

            '	Determine the size and location of the drag rectangle if
            '	the current mouse position is outside this rectangle, we will
            '	initiate a drag operation.
            Dim dragSize As Size = SystemInformation.DragSize
            Dim dragRect As Rectangle = New Rectangle(lastMouseDown, dragSize)
            dragRect.X -= (dragSize.Width / 2)
            dragRect.Y -= (dragSize.Height / 2)

            '	If the current cursor position is within the bounds of the
            '	drag rectangle, fire the DragOperationStarting event.
            Dim cursorPos As Point = New Point(e.X, e.Y)
            If (dragRect.Contains(cursorPos) = False) Then

                '   Call the IDragSource interface implementor's OnDragOperationStarting method
                Dim info As DragOperationStartingInfo = New DragOperationStartingInfo()
                Me._dragSource.OnDragOperationStarting(info)


                '	If the event was not canceled, and drag data was assigned by
                '	a listener of the event, cache the drag data, which we will
                '	need later if the drop occurs.
                If info.CancelResolved = False Then

                    '	Cache the drag data
                    Me._dragData = info.Data

                    '	If the DragImageElements of the event arguments was set,
                    '	Create the drag image and use the DragDropIndicatorManager
                    '	to display it.
                    If Not info.DragImageElements Is Nothing Then
                        If Me._dragImageManager Is Nothing Then Me._dragImageManager = New DragImageManager()
                        Me._dragImageManager.Initialize(info.DragImageElements)
                    End If

                    '	Call the DoDragDrop method to begin the drag operation
                    Me.Control.DoDragDrop(Me._dragData, DragDropManager.supportedDragDropEffects)
                Else
                    Me.OnDragOperationCompleted(True)
                End If
            End If

        End If

    End Sub

    ' <summary>
    ' Handles the QueryContinueDrag event of the associated control.
    ' </summary>
    Private Sub OnQueryContinueDrag(ByVal sender As Object, ByVal e As QueryContinueDragEventArgs)

        '	If the DragOperationContinuing event was canceled, our reference
        '	to the the drag data will have been nullified, so terminate the
        '	drag operation if that is the case.
        If Me._dragData Is Nothing Then e.Action = DragAction.Cancel

        '	If the Action is 'Cancel' or 'Drop', fire the DragOperationCompleting event
        If e.Action = DragAction.Cancel Or e.Action = DragAction.Drop Then

            '   Call the IDragSource interface implementor's OnDragOperationCompleting method
            Dim info As DragOperationCompletingInfo = New DragOperationCompletingInfo(Me._dragData, Me._dragDropEffect, e.Action = DragAction.Drop)
            Me._dragSource.OnDragOperationCompleting(info)

            '	If any listener set the 'Cancel' property to true, cancel
            '	the drag operation by setting the Action property of the
            '	QueryContinueDragEventArgs.
            If (info.Cancel) Then e.Action = DragAction.Cancel

            Me.OnDragOperationCompleted(e.Action = DragAction.Cancel)

            '	If the Action is 'Continue' and we are displaying a drag image,
            '	move it to the new cursor position
        Else

            '	If we are displaying a drag image, move it to the new cursor position
            If Not Me._dragImageManager Is Nothing Then
                Me._dragImageManager.ShowDragImage(System.Windows.Forms.Control.MousePosition)
            End If
        End If

    End Sub

    ' <summary>
    ' Handles the GiveFeedback event of the associated control.
    ' </summary>
    Private Sub OnGiveFeedback(ByVal sender As Object, ByVal e As GiveFeedbackEventArgs)

        '   Call the IDragSource interface implementor's OnDragOperationContinuing method
        Dim info As DragOperationContinuingInfo = New DragOperationContinuingInfo(Me._dragData, e.Effect)
        Me._dragSource.OnDragOperationContinuing(info)

        '	If the event was canceled, nullify our reference to the
        '	drag data, so that the OnQueryContinueDrag method knows
        '	the the drag operation was canceled
        If info.Cancel Then Me._dragData = Nothing

        '   Set the cursors, if the IDragSource implementation returns specific ones.
        Dim dragMoveCursor As Cursor = Me._dragSource.DragMoveCursor
        Dim dragCopyCursor As Cursor = Me._dragSource.DragCopyCursor

        If (info.Effect = DragDropEffects.Copy AndAlso Not dragCopyCursor Is Nothing) Then
            e.UseDefaultCursors = False
            Cursor.Current = dragCopyCursor
        ElseIf (info.Effect = DragDropEffects.Move AndAlso Not dragMoveCursor Is Nothing) Then
            e.UseDefaultCursors = False
            Cursor.Current = dragMoveCursor
        Else
            e.UseDefaultCursors = True

        End If

        '	Cache the last Effect setting so we know where we stand
        '	when we fire the DragOperationCompleting event.
        Me._dragDropEffect = info.Effect
        Debug.WriteLine("Me._dragDropEffect = " + Me._dragDropEffect.ToString())

    End Sub

    ' <summary>
    ' Handles the DragOver event of the associated control.
    ' </summary>
    Private Sub OnDragOver(ByVal sender As Object, ByVal e As DragEventArgs)
        '   Call the IDropTarget interface implementor's OnDropTargetNotify method.
        Dim info As DropTargetNotifyInfo = New DropTargetNotifyInfo(e, DropTargetNotification.DragOver)
        Me._dropTarget.OnDropTargetNotify(info)
        e.Effect = info.Effect
        Debug.WriteLine("OnDragOver: e.Effect = " + e.Effect.ToString())
    End Sub

    ' <summary>
    ' Handles the DragDrop event of the associated control.
    ' </summary>
    Private Sub OnDragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
        '   Call the IDropTarget interface implementor's OnDropTargetNotify method.
        Dim info As DropTargetNotifyInfo = New DropTargetNotifyInfo(e, DropTargetNotification.DragDrop)
        Me._dropTarget.OnDropTargetNotify(info)
    End Sub

#End Region

#Region "IDisposable"
    ' <summary>
    ' Disposes of this instance.
    ' </summary>
    Public Sub Dispose() Implements IDisposable.Dispose
        '   Unhook from the event notification list
        Me.HookEvents(False)

        '	Dispose of the DragImageManager
        If Not Me._dragImageManager Is Nothing Then
            Me._dragImageManager.Dispose()
            Me._dragImageManager = Nothing
        End If

    End Sub


#End Region

#Region "DragOperationInfoBase"
    ' <summary>
    ' Base class for the drag operation classes.
    ' </summary>
    Public Class DragOperationInfoBase

        Private _cancel As Boolean

        ' <summary>
        ' Gets/sets whether the drag operation should be canceled.
        ' </summary>
        Public ReadOnly Property Cancel() As Boolean
            Get
                Return Me._cancel
            End Get
        End Property

    End Class
#End Region

#Region "DragOperationStartingInfo"
    Public Class DragOperationStartingInfo
        Inherits DragOperationInfoBase

        Private _data As Object
        Private _dragImageElements As UIElement() = Nothing

        ' <summary>
        ' Gets/sets the data associated with this drag operation.
        ' </summary>
        Public Property Data() As Object
            Get
                Return Me._data
            End Get
            Set(ByVal Value As Object)
                Me._data = Value
            End Set
        End Property

        ' <summary>
        ' Gets/sets the array of UIElements which will be used to render the
        ' image that represents the contents of the drag operation.
        ' </summary>
        Public Property DragImageElements() As UIElement()
            Get
                Return Me._dragImageElements
            End Get
            Set(ByVal Value As UIElement())
                Me._dragImageElements = Value
            End Set
        End Property

        ' <summary>
        ' Returns whether the event has been logically canceled,
        ' i.e., whether the 'Cancel' property has been set to true,
        ' there is no data to drop, or no drag operation type was specified.
        ' </summary>
        Public ReadOnly Property CancelResolved() As Boolean
            Get
                Return Me.Cancel = True Or Me.Data Is Nothing
            End Get
        End Property

    End Class
#End Region

#Region "DragOperationContinuingInfo"
    Public Class DragOperationContinuingInfo
        Inherits DragOperationInfoBase

        Private _data As Object
        Private _effect As DragDropEffects = DragDropEffects.None

        Public Sub New(ByVal dragData As Object, ByVal effect As DragDropEffects)
            MyBase.New()
            Me._data = dragData
            Me._effect = effect
        End Sub

        ' <summary>
        ' Gets/sets the data associated with this drag operation.
        ' </summary>
        Public Property Data() As Object
            Get
                Return Me._data
            End Get
            Set(ByVal Value As Object)
                Me._data = Value
            End Set
        End Property

        ' <summary>
        ' Returns the DragDropEffects
        ' </summary>
        Public Property Effect() As DragDropEffects
            Get
                Return Me._effect
            End Get
            Set(ByVal Value As DragDropEffects)
                Me._effect = Value
            End Set
        End Property

    End Class
#End Region

#Region "DragOperationCompletingInfo"
    Public Class DragOperationCompletingInfo
        Inherits DragOperationInfoBase

        Private _data As Object
        Private _effect As DragDropEffects = DragDropEffects.None
        Private _committed As Boolean = True

        Public Sub New(ByVal dragData As Object, ByVal effect As DragDropEffects, ByVal committed As Boolean)
            MyBase.New()
            Me._data = dragData
            Me._effect = effect
            Me._committed = committed
        End Sub

        ' <summary>
        ' Gets/sets the data associated with this drag operation.
        ' </summary>
        Public ReadOnly Property Data() As Object
            Get
                Return Me._data
            End Get
        End Property

        ' <summary>
        ' Returns the DragDropEffects
        ' </summary>
        Public ReadOnly Property Effect() As DragDropEffects
            Get
                Return Me._effect
            End Get
        End Property

        ' <summary>
        ' Returns a boolean indicating whether the drag operation was committed,
        ' i.e., none of the other cancelable events were canceled, and the end user
        ' did not press the Escape key.
        ' </summary>
        Public ReadOnly Property Committed() As Boolean
            Get
                Return Me._committed
            End Get
        End Property

    End Class
#End Region

#Region "DropTargetNotifyInfo"
    ' <summary>
    ' Event arguments class for the DragDropManager's 'DropTargetNotify' event.
    ' </summary>
    Public Class DropTargetNotifyInfo

        Private _dragInfo As DragEventArgs
        Private _dropTargetNotification As DropTargetNotification

        Public Sub New(ByRef dragInfo As DragEventArgs, ByVal dropTargetNotification As DropTargetNotification)
            MyBase.New()
            Me._dragInfo = dragInfo
            Me._dropTargetNotification = dropTargetNotification
        End Sub

        ' <summary>
        ' Returns the DragDropEffects
        ' </summary>
        Public Property Effect() As DragDropEffects
            Get
                Return Me._dragInfo.Effect
            End Get

            Set(ByVal Value As DragDropEffects)
                Me._dragInfo.Effect = Value
            End Set
        End Property


        ' <summary>
        ' Gets/sets the IDataObject implementor which contains
        ' the data associated with this drag operation.
        ' </summary>
        Public ReadOnly Property Data() As IDataObject
            Get
                Return Me._dragInfo.Data
            End Get
        End Property

        ' <summary>
        ' Returns which drag/drop operations are allowed by the drag source.
        ' </summary>
        Public ReadOnly Property AllowedEffect() As DragDropEffects
            Get
                Return Me._dragInfo.AllowedEffect
            End Get
        End Property

        ' <summary>
        ' Returns whether the ALT key is currently pressed.
        ' </summary>
        Public ReadOnly Property IsAltKeyPressed() As Boolean
            Get
                Return (Me._dragInfo.KeyState And DragDropManager.numericCodeAlt) = DragDropManager.numericCodeAlt
            End Get
        End Property

        ' <summary>
        ' Returns whether the CONTROL key is currently pressed.
        ' </summary>
        Public ReadOnly Property IsControlKeyPressed() As Boolean
            Get
                Return (Me._dragInfo.KeyState And DragDropManager.numericCodeControl) = DragDropManager.numericCodeControl
            End Get
        End Property

        ' <summary>
        ' Returns whether the SHIFT key is currently pressed.
        ' </summary>
        Public ReadOnly Property IsShiftKeyPressed() As Boolean
            Get
                Return (Me._dragInfo.KeyState And DragDropManager.numericCodeShift) = DragDropManager.numericCodeShift
            End Get
        End Property

        ' <summary>
        ' Returns whether the notification was triggered by the
        ' DragOver event or the DragDrop event.
        ' </summary>
        Public ReadOnly Property DropTargetNotification() As DropTargetNotification
            Get
                Return Me._dropTargetNotification
            End Get
        End Property

    End Class
#End Region

#Region "DropTargetNotification enumeration"
    'Constants which identify the type of drop target notification.
    Public Enum DropTargetNotification

        ' No drag operations are supported.
        None

        ' The DragOver event.
        DragOver

        ' The DragDrop event.
        DragDrop

    End Enum
#End Region

#Region "DragImageManager class"
    ' <summary>
    '	Generates the image displayed by a drag source (and its associated
    '	non-transparent region) while a drag operation is taking place.
    ' </summary>
    Public Class DragImageManager
        Implements IDisposable

        Private Shared ReadOnly dragImageOffset As New Point(2, 2)
        Private Shared ReadOnly dragImageAlphaFactor As Single = 0.33

        Private _dragDropIndicatorManager As DragDropIndicatorManager = Nothing
        Private _dragImage As Bitmap = Nothing
        Private _dragImageRegion As Region

        ' <summary>
        ' Creates a new instance of the <see cref="DragImageManager"/>
        ' </summary>
        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub Initialize(ByVal dragElements As UIElement())
            '	Dispose of this instance, which will release any previously
            '	used resources.
            Me.Dispose()

            '	Create the drag image and its region
            Me.CreateDragImage(dragElements)
        End Sub

        ' <summary>
        ' Generates the image that is displayed to depict the contents of the drag operation.
        ' </summary>
        ' <param name="dragElements">An array of UIElements from which the image is generated.</param>
        Public Sub CreateDragImage(ByVal dragElements As UIElement())

            If dragElements Is Nothing Then Return
            If dragElements.Length = 0 Then Return

            '	Calculate the bounds of a rectangle which contains all the elements
            Dim left As Integer = Short.MaxValue
            Dim top As Integer = Short.MaxValue
            Dim right As Integer = 0
            Dim bottom As Integer = 0

            '	Calculate the bounds of a rectangle which contains all the elements
            Dim i As Integer
            For i = 0 To dragElements.Length - 1
                Dim element As UIElement = dragElements(i)
                If Not element Is Nothing Then
                    Dim elementRect As Rectangle = element.Rect
                    left = Math.Min(left, elementRect.Left)
                    top = Math.Min(top, elementRect.Top)
                    right = Math.Max(right, elementRect.Right)
                    bottom = Math.Max(bottom, elementRect.Bottom)
                End If
            Next

            Dim renderingOffset As Point = New Point(left, top)
            Dim size As Size = New Size(right - left, bottom - top)
            Dim bounds As Rectangle = New Rectangle(Point.Empty, size)

            '	Create the Bitmap which we will draw on to create the drag image
            Me._dragImage = New Bitmap(size.Width, size.Height)

            Dim gr As Graphics = Nothing
            Dim matrix As Matrix = Nothing

            Try

                '	Create a Graphics object from the Bitmap we created above
                '	fill it with the transparent color and offset its rendering origin.
                gr = Graphics.FromImage(Me._dragImage)

                '	Transform the coordinate system to shift the point of origin
                matrix = New System.Drawing.Drawing2D.Matrix(1, 0, 0, 1, renderingOffset.X * -1, renderingOffset.Y * -1)
                gr.Transform = matrix

                '	Get the BackColor of the parent form...we need to use this as the background color
                '	because when we draw the UIElements to the Graphics object, transparent areas will
                '	be drawn with this color, and we want those areas to be masked out of the resulting image.
                Dim parentFormBackColor As Color = IIf(Not dragElements(0) Is Nothing, dragElements(0).Control.BackColor, Form.DefaultBackColor)
                gr.Clear(parentFormBackColor)

                '	Draw each element onto the Graphics object
                For i = 0 To dragElements.Length - 1

                    Dim element As UIElement = dragElements(i)
                    If Not element Is Nothing Then
                        element.Draw(gr, element.Rect, True, AlphaBlendMode.Disabled)
                    End If

                Next

                '	Generate a Region from the Bitmap we just created above
                Me._dragImageRegion = ImageManager.CreateBitmapRegion(Me._dragImage, parentFormBackColor)

                '	Adjust the opacity of the drag image to give it
                '	a semi-transparent, "ghosted" appearance.
                Me.AdjustTransparency(Me._dragImage)

            Finally

                '	Dispose of the Graphics and Matrix objects
                If Not gr Is Nothing Then gr.Dispose()
                If Not matrix Is Nothing Then matrix.Dispose()
            End Try
        End Sub

        ' <summary>
        ' Adjusts the transparency of the specified image.
        ' </summary>
        ' <param name="dragImage">The image to adjust</param>
        Private Sub AdjustTransparency(ByVal dragImage As Bitmap)
            If dragImage Is Nothing Then Return

            Dim bitmapData As BitmapData = Nothing

            Try
                Dim rect As Rectangle = New Rectangle(Point.Empty, dragImage.Size)
                Dim width As Integer = dragImage.Size.Width
                Dim height As Integer = dragImage.Size.Height
                bitmapData = dragImage.LockBits(rect, ImageLockMode.ReadWrite, dragImage.PixelFormat)
                Dim pixelData As Byte()
                ReDim pixelData((rect.Height * bitmapData.Stride) - 1)
                Dim pixelSize As Integer = bitmapData.Stride / width

                ' Get the pixel data into the byte array
                Marshal.Copy(bitmapData.Scan0, pixelData, 0, pixelData.Length)

                '	Iterate the scan lines of the bitmap, and reduce the opacity
                '	of each pixel to make them semi-transparent.
                Dim x As Integer, y As Integer
                For y = 0 To height - 1

                    Dim offset As Integer = y * bitmapData.Stride

                    For x = 0 To width - 1

                        Dim alpha As Byte = pixelData(offset + 3)
                        If alpha <> 0 Then
                            pixelData(offset + 3) = alpha * DragImageManager.dragImageAlphaFactor
                        End If

                        offset += pixelSize
                    Next
                Next

                ' Copy the manipulated bytes back into the bitmap
                Marshal.Copy(pixelData, 0, bitmapData.Scan0, pixelData.Length)
            Finally
                If Not bitmapData Is Nothing Then dragImage.UnlockBits(bitmapData)
            End Try

        End Sub

        ' <summary>
        ' Shows the drag image at the specified location.
        ' </summary>
        ' <param name="location">The location at which to display the image, expressed in coordinates relative to the screen.</param>
        Public Sub ShowDragImage(ByVal location As Point)
            If Me._dragImage Is Nothing Then Return

            If Me._dragDropIndicatorManager Is Nothing Then

                '	Note that the constructor parameters are meaningless here (there is no parameterless ctor).
                Me._dragDropIndicatorManager = New DragDropIndicatorManager(Orientation.Horizontal, Nothing)
                Me._dragDropIndicatorManager.InitializeDragIndicator(Me._dragImage, Me._dragImageRegion)
                Me._dragDropIndicatorManager.DragIndicatorOffset = DragImageManager.dragImageOffset
            End If

            Me._dragDropIndicatorManager.ShowDragIndicator(location)
        End Sub

        ' <summary>
        ' Hides the drag image.
        ' </summary>
        Public Sub HideDragImage()
            If Not Me._dragDropIndicatorManager Is Nothing Then Me._dragDropIndicatorManager.HideDragIndicator()
        End Sub

        ' <summary>
        ' Disposes of this instance.
        ' </summary>
        Public Sub Dispose() Implements IDisposable.Dispose
            If Not Me._dragDropIndicatorManager Is Nothing Then
                If Me._dragDropIndicatorManager.Disposed = False Then
                    If Me._dragDropIndicatorManager.IsDragIndicatorVisible Then
                        Me._dragDropIndicatorManager.HideDragIndicator()
                    End If

                    Me._dragDropIndicatorManager.Dispose()
                End If

                Me._dragDropIndicatorManager = Nothing
            End If

            '   Dispose of the drag image
            If Not Me._dragImage Is Nothing Then
                Me._dragImage.Dispose()
                Me._dragImage = Nothing
            End If

            '   Dispose of the region we created from the drag image
            If Not Me._dragImageRegion Is Nothing Then
                Me._dragImageRegion.Dispose()
                Me._dragImageRegion = Nothing
            End If
        End Sub

    End Class
#End Region

#Region "IDragSource interface definition"
    Public Interface IDragSource

        ' <summary>
        ' Returns the UltraControlBase-derived control which acts as the drag source.
        ' </summary>
        ReadOnly Property Control() As UltraControlBase

        ' <summary>
        ' Called when a drag operation is about to begin.
        ' </summary>
        ' <param name="info">The <see cref="DragOperationStartingInfo"/> instance which contains information relevant to the drag operation.</param>
        Sub OnDragOperationStarting(ByVal info As DragOperationStartingInfo)

        ' <summary>
        ' Called when a drag operation is in progress.
        ' </summary>
        ' <param name="info">The <see cref="DragOperationContinuingInfo"/> instance which contains information relevant to the drag operation.</param>
        Sub OnDragOperationContinuing(ByVal info As DragOperationContinuingInfo)

        ' <summary>
        ' Called when a drag operation is about to be completed.
        ' </summary>
        ' <param name="info">The <see cref="DragOperationCompletingInfo"/> instance which contains information relevant to the drag operation.</param>
        Sub OnDragOperationCompleting(ByVal info As DragOperationCompletingInfo)

        ' <summary>
        ' Returns the type of the UIElement which is hit-tested before a drag
        ' operation is initiated; if this property returns a non-null value,
        ' a UIElement of this type must be found at the cursor position before
        ' a drag operation is initiated. Can return null, in which case the
        ' drag operation is initiated regardless of whether a draggable item
        ' is found at the cursor position.
        ' </summary>
        ReadOnly Property HitTestElementType() As Type

        ' <summary>
        ' Returns the cursor that should be displayed during a drag move operation.
        ' Can return null, in which case the default cursor is displayed.
        ' </summary>
        ReadOnly Property DragMoveCursor() As Cursor

        ' <summary>
        ' Returns the cursor that should be displayed during a drag copy operation.
        ' Can return null, in which case the default cursor is displayed.
        ' </summary>
        ReadOnly Property DragCopyCursor() As Cursor

    End Interface
#End Region

#Region "IDropTarget interface definition"
    Public Interface IDropTarget

        ' <summary>
        ' Returns the UltraControlBase-derived control which acts as the drag source.
        ' </summary>
        ReadOnly Property Control() As UltraControlBase

        ' <summary>
        ' Called to notify a drop target about the progress of a drag/drop operation
        ' </summary>
        ' <param name="info">The <see cref="DropTargetNotifyInfo"/> instance which contains information relevant to the drop.</param>
        Sub OnDropTargetNotify(ByVal info As DropTargetNotifyInfo)

    End Interface
#End Region

End Class
#End Region
