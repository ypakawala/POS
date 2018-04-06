Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinListView

Public Class WinListViewDropTarget
    Implements DragDropManager.IDropTarget

    Private _listView As UltraListView = Nothing

    ' <summary>
    ' Creates a new instance of the <see cref="WinListViewDragSource"/> class.
    ' </summary>
    ' <param name="listView">The UltraListView control with which this instance is associated.</param>
    Public Sub New(ByVal listView As UltraListView)
        If listView Is Nothing Then Throw New ArgumentNullException("listView")

        Me._listView = listView
    End Sub

    '   Implements the Control property.
    Public ReadOnly Property Control() As UltraControlBase Implements DragDropManager.IDropTarget.Control
        Get
            Return Me._listView
        End Get
    End Property


    '   Implements the OnDropTargetNotify method.
    Public Sub OnDropTargetNotify(ByVal info As DragDropManager.DropTargetNotifyInfo) Implements DragDropManager.IDropTarget.OnDropTargetNotify

        Dim listView As UltraListView = Me._listView

        Select Case info.DropTargetNotification
            '	If the drop notification type is 'DragOver', read the state of the
            '	Control key and set the 'Effect' property accordingly, so that the
            '	drag source knows which drag cursor to display, and also whether the
            '	drag data should be removed from the drag source info.
            Case DragDropManager.DropTargetNotification.DragOver
                info.Effect = IIf(info.IsControlKeyPressed, DragDropEffects.Copy, DragDropEffects.Move)

                '	If the drop notification type is 'DragDrop', add the items to
                '	the drop target's Items collection.
            Case DragDropManager.DropTargetNotification.DragDrop

                Dim dataObject As IDataObject = info.Data
                Dim items As UltraListViewItem() = dataObject.GetData(GetType(UltraListViewItem()))
                If Not items Is Nothing Then

                    '	If we are copying the items, clone each oninfo...note that for this
                    '	demonstration we will not include subitems, but this could be easily
                    '	changed to support this.
                    If (info.Effect = DragDropEffects.Copy) Then

                        Dim i As Integer
                        For i = items.Length - 1 To 0 Step -1

                            items(i) = items(i).Clone()
                        Next
                    End If

                    listView.Items.AddRange(items)
                End If
        End Select

    End Sub

    Public ReadOnly Property Control() As Infragistics.Win.UltraControlBase Implements DragDropManager.IDropTarget.Control
        Get

        End Get
    End Property
End Class

