
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinListView
Imports Infragistics.Win.UltraWinListView.UltraListViewItem


Public Class WinListViewDragSource
    Implements DragDropManager.IDragSource

    Private _listView As UltraListView = Nothing
    Private _dragMoveCursor As Cursor = Nothing
    Private _dragCopyCursor As Cursor = Nothing

    ' <summary>
    ' Creates a new instance of the <see cref="WinListViewDragSource"/> class.
    ' </summary>
    ' <param name="listView">The UltraListView control with which this instance is associated.</param>
    Public Sub New(ByVal listView As UltraListView)
        Me.New(listView, Nothing, Nothing)
    End Sub

    ' <summary>
    ' Creates a new instance of the <see cref="WinListViewDragSource"/> class.
    ' </summary>
    ' <param name="listView">The UltraListView control with which this instance is associated.</param>
    ' <param name="dragMoveCursor">The cursor to display during a drag move operation.</param>
    ' <param name="dragCopyCursor">The cursor to display during a drag copy operation.</param>
    Public Sub New(ByVal listView As UltraListView, ByVal dragMoveCursor As Cursor, ByVal dragCopyCursor As Cursor)
        MyBase.New()

        If listView Is Nothing Then Throw New ArgumentNullException("listView")

        Me._listView = listView
        Me._dragMoveCursor = dragMoveCursor
        Me._dragCopyCursor = dragCopyCursor
    End Sub

    '   Implements the Control property.
    Public ReadOnly Property Control() As UltraControlBase Implements DragDropManager.IDragSource.Control
        Get
            Return Me._listView
        End Get
    End Property

    '   Implements the DragMoveCursor property.
    Public ReadOnly Property DragMoveCursor() As Cursor Implements DragDropManager.IDragSource.DragMoveCursor
        Get
            Return Me._dragMoveCursor
        End Get
    End Property

    '   Implements the DragCopyCursor property.
    Public ReadOnly Property DragCopyCursor() As Cursor Implements DragDropManager.IDragSource.DragCopyCursor
        Get
            Return Me._dragCopyCursor
        End Get
    End Property

    '   Implements the HitTestElementType property.
    Public ReadOnly Property HitTestElementType() As Type Implements DragDropManager.IDragSource.HitTestElementType
        Get
            Return GetType(UltraListViewItemUIElement)
        End Get
    End Property

    '   Implements the OnDragOperationStarting method.
    Public Sub OnDragOperationStarting(ByVal info As DragDropManager.DragOperationStartingInfo) Implements DragDropManager.IDragSource.OnDragOperationStarting

        Dim listView As UltraListView = Me._listView

        '	Get a snapshot of the SelectedItems collection into an array
        Dim selectedItems As UltraListViewSelectedItemsCollection = listView.SelectedItems
        Dim dragData As UltraListViewItem()
        ReDim dragData(selectedItems.Count - 1)
        selectedItems.CopyTo(dragData, 0)

        '	Assign the UltraListViewItem array to the Drag property of the event arguments
        '	this array will be passed around for the lifetime of the drag operation
        info.Data = dragData

        '	Get another array, this one containing the UIElement for each of the
        '	selected items these elements are used to generate an image which is
        '	displayed during the drag operation, so the end user can see what is
        '	being dragged. Assign this array to the 'DragImageElements' property
        '	of the event arguments.
        info.DragImageElements = WinListViewDragSource.GetDragImageElements(listView.View, dragData)
    End Sub

    '	Returns an array of UIElements which should be displayed in the drag image
    '	based on the specified view and UltraListViewItem array.
    Private Shared Function GetDragImageElements(ByVal view As UltraListViewStyle, ByVal items As UltraListViewItem()) As UIElement()

        If items Is Nothing Then Return Nothing
        If items.Length = 0 Then Return Nothing

        Dim elementList As ArrayList = New ArrayList(CType(IIf(view = UltraListViewStyle.Details, items.Length * 2, items.Length), Integer))

        Dim i As Integer
        For i = 0 To items.Length - 1

            Dim itemElement As UltraListViewItemUIElement = items(i).UIElement
            If Not itemElement Is Nothing Then

                Select Case (view)

                    Case UltraListViewStyle.Details

                        elementList.Add(itemElement.GetDescendant(GetType(UltraListViewImageUIElement)))
                        elementList.Add(itemElement.GetDescendant(GetType(UltraListViewMainItemTextAreaUIElement)))

                    Case Else
                        elementList.Add(itemElement)
                End Select
            End If
        Next

        Return elementList.ToArray(GetType(UIElement))
    End Function

    '   Implements the OnDragOperationContinuing method.
    Public Sub OnDragOperationContinuing(ByVal info As DragDropManager.DragOperationContinuingInfo) Implements DragDropManager.IDragSource.OnDragOperationContinuing

        '	Note that this method can be handled to cancel the drag operation,
        '	or display non-default cursors. The DragDropManager's default
        '	implementation handles the display of the move and copy cursors,
        '	which is all we need for this demonstration, so we don't need to
        '	do anything else here.
    End Sub

    '   Implements the OnDragOperationCompleting method.
    Public Sub OnDragOperationCompleting(ByVal info As DragDropManager.DragOperationCompletingInfo) Implements DragDropManager.IDragSource.OnDragOperationCompleting

        Dim listView As UltraListView = Me._listView

        '	If the drag operation is being committed, and it is a move
        '	operation, remove the items from the drag source's Items collection.
        If info.Committed AndAlso info.Effect = DragDropEffects.Move Then

            Dim items As UltraListViewItem() = info.Data
            If Not items Is Nothing Then

                Dim i As Integer
                For i = items.Length - 1 To 0 Step -1
                    listView.Items.Remove(items(i))
                Next
            End If
        End If
    End Sub

    Public ReadOnly Property Control() As Infragistics.Win.UltraControlBase Implements DragDropManager.IDragSource.Control
        Get

        End Get
    End Property
End Class

