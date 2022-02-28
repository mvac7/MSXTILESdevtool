Public Class PathItem

    Public pathUser As String
    Public pathLast As String

    Private _Type As PATH_TYPE



    Public Shadows Enum PATH_TYPE As Integer
        USER
        LAST_USED
    End Enum



    Public Property Path() As String
        Get
            Select Case _Type
                'Case PATH_TYPE.LAST_USED
                '    Return pathLast
                Case PATH_TYPE.USER
                    Return pathUser
                Case Else
                    Return pathLast
            End Select
        End Get
        Set(value As String)
            If value = "" Then
                value = Application.StartupPath
            End If
            Select Case _Type
                'Case PATH_TYPE.LAST_USED
                '    pathLast = value
                Case PATH_TYPE.USER
                    Me.pathUser = value
                Case Else
                    Me.pathLast = value
            End Select
        End Set
    End Property



    Public Property TypePath As PATH_TYPE
        Get
            Return _Type
        End Get
        Set(value As PATH_TYPE)
            _Type = value
        End Set
    End Property




    Public Sub New()
        _Type = PATH_TYPE.LAST_USED
        Me.pathUser = Application.StartupPath
        Me.pathLast = Application.StartupPath
    End Sub


    Public Sub New(aType As PATH_TYPE, aPath As String)
        Me._Type = aType
        Me.pathUser = aPath
        Me.pathLast = aPath
    End Sub


    Public Sub New(aType As PATH_TYPE, aPathUser As String, aPathLast As String)
        Me._Type = aType
        Me.pathUser = aPathUser
        Me.pathLast = aPathLast
    End Sub


    Public Sub UpdateLastPath(value As String)
        Me.pathLast = value
    End Sub



End Class
