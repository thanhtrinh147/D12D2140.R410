Imports System
Public Class D07F6150

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker

    Private ChildName As String = "D07E0430"
    Dim exe As D07E0430

    Private _inventoryID As String
    Public WriteOnly Property InventoryID() As String
        Set(ByVal Value As String)
            _inventoryID = Value
        End Set
    End Property

    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        Try
            'Tạo một process gắn với exe con, process này sẽ quan sát exe con.
            Dim p As System.Diagnostics.Process

            p = Process.GetProcessesByName(ChildName)(0)
        
            If p Is Nothing Then
                Me.Close()
                Exit Sub
            End If

            p.EnableRaisingEvents = True
            p.WaitForExit()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ẩn form trung gian
        Me.Size = New Size(0, 0)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        '----Truyền tham số exe con------
        exe = New D07E0430(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        exe.FormActive = D07E0430Form.D07F6150
        exe.ID01 = _inventoryID

        exe.Run()
        '------------------------------------

        'Bắt đầu chạy cơ chế background
        backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        backgroundWorker1.RunWorkerAsync()
    End Sub

    'sự kiện hoàn thành và dừng của Background
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        Me.Close()
    End Sub

End Class
