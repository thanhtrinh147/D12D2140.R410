Imports System
Public Class D07M1440

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private ChildName As String = "D07E1440"

    Private exe As D07E1440

    'Phân biệt các form được gọi trong class D07E1240
    Private _formName As String = ""
    Public WriteOnly Property FormName() As String
        Set(ByVal Value As String)
            _formName = Value
        End Set
    End Property

    Private _formPermission As String = ""
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


    'Trả về giá trị LocationNo (Lô nhập) từ form D07F1211 hoặc công thức từ D07F0112
    Private _Output01 As String = ""
    Public ReadOnly Property Output01() As String
        Get
            Return _Output01
        End Get
    End Property

    Private _savedOK As Boolean = False
    Public Property SavedOK() As Boolean
        Get
            Return _savedOK
        End Get
        Set(ByVal Value As Boolean)
            _savedOK = Value
        End Set
    End Property

    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        'Tạo một process gắn với exe con, process này sẽ quan sát exe con.
        Dim p As System.Diagnostics.Process

        Try
            p = Process.GetProcessesByName(ChildName)(0)

            If p Is Nothing Then
                Exit Sub
            End If

            'Chờ đợi exe con tắt tiến trình 
            p.EnableRaisingEvents = True
            p.WaitForExit()

        Catch ex As Exception
            MsgBox(ex.Message & " - " & ex.Source)
        End Try
    End Sub

    Public Sub FormLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ẩn form trung gian
        Me.Size = New Size(0, 0)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        '----Truyền tham số exe con------
        exe = New D07E1440(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString(), gsDivisionID, giTranMonth, giTranYear)

        exe.FormActive = _formName
        If _formPermission = "" Then _formPermission = _formName
        exe.FormPermission = _formPermission
        exe.ID01 = _iD01
        exe.Run()

        backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        backgroundWorker1.RunWorkerAsync()

        'If _formName = "D07F0034" OrElse _formName = "D07F9004" Then 'Cơ chế đợi
        '    'Bắt đầu chạy cơ chế background
        '    backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        '    backgroundWorker1.RunWorkerAsync()
        'Else ' Cơ chế không đợi
        '    Me.Close()
        'End If

    End Sub

    'sự kiện hoàn thành và dừng của Background
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        _Output01 = exe.Output01
        _savedOK = exe.Output02
        Me.Close()
    End Sub

End Class
