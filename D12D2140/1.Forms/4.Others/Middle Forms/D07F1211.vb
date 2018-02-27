Imports System

Public Class D07F1211
    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker

    Private Const EXECHILD As String = "D07E0140"
    Dim exe As D07E0140

    Private _out_LocationNo As String
    Public ReadOnly Property Out_LocationNo() As String
        Get
            Return _out_LocationNo
        End Get
    End Property

    Dim p As System.Diagnostics.Process

    Private Sub FormLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ẩn form trung gian
        Me.Size = New Size(0, 0)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None


        '----Truyền tham số exe con------
        exe = New D07E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        exe.FormActive = "D07F1211"
        exe.FormPermission = "D07F1210"
        exe.Ctrl02 = "1"

        'xóa dl cũ
        D99C0007.SaveModulesSetting("D07", ModuleOption.lmLastValues, "LocationNo", "")
        exe.Run()
        '------------------------------------

        'Tạo một process gắn với exe con, process này sẽ quan sát exe con.
        Try
            p = Process.GetProcessesByName(EXECHILD)(0)
        Catch ex As Exception
        End Try
        If p Is Nothing Then
            D99C0008.MsgL3("Process " & EXECHILD & " is not running")
            Me.Close()
            Exit Sub
        End If


        'Bắt đầu chạy cơ chế background
        backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        backgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork

        'Chờ đợi exe con tắt tiến trình 
        p.EnableRaisingEvents = True
        p.WaitForExit()
    End Sub

    'sự kiện hoàn thành và dừng của Background
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        Me.Close()
    End Sub

    'Lấy giá trị trả về ở sự kiện này
    Private Sub D07F1211_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        _out_LocationNo = D99C0007.GetModulesSetting("D07", ModuleOption.lmLastValues, "LocationNo", "")

    End Sub

End Class
