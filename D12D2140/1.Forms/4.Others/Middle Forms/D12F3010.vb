Imports System
Public Class D12F3010

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker

    Private ChildName As String = "D12E4140"
    Dim exe As D12E4140

    Private _formActive As String = ""
    Public WriteOnly Property FormActive() As String
        Set(ByVal Value As String)
            _formActive = Value
        End Set
    End Property

    Private _formPermission As String=""
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            _formPermission = Value
        End Set
    End Property

    Private _iD01 As String = ""
    Public WriteOnly Property ID01() As String
        Set(ByVal Value As String)
            _iD01 = Value
        End Set
    End Property

    Private _formState As EnumFormState = EnumFormState.FormAdd
    Public WriteOnly Property FormState() As EnumformState
        Set(ByVal Value As EnumformState)
            _formState = Value
        End Set
    End Property

    Private _iD02 As String = ""
    Public WriteOnly Property ID02() As String
        Set(ByVal Value As String)
            _iD02 = Value
        End Set
    End Property


    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        Try
            'Tạo một process gắn với exe con, process này sẽ quan sát exe con.
            Dim p As System.Diagnostics.Process
            p = Process.GetProcessesByName(ChildName)(0)
            If p Is Nothing Then
                'D99C0008.MsgL3("Process " & ChildName & " is not running")
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
        exe = New D12E4140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        exe.FormShow = _formActive
        exe.FormPermission = _formPermission
        exe.FormState = _formState
        exe.ID01 = _iD01
        exe.ID02 = _iD02
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

    Private Sub D21F0005_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub
End Class
