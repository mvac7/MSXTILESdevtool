Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class RoundedPanel
    Inherits Panel



    Private _radius As Integer = 20


    <Browsable(True)>
    Public Property Radius() As Integer
        Get
            Return _radius
        End Get
        Set(ByVal Value As Integer)
            _radius = Value
            Invalidate()
        End Set
    End Property



    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs) 'OnPaintBackground
        MyBase.OnPaint(e)

        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim aGraphicsPath As GraphicsPath = New GraphicsPath()
        aGraphicsPath.StartFigure()
        aGraphicsPath.AddArc(GetLeftUpper(), 180, 90)
        aGraphicsPath.AddLine(Radius, 0, Width - Radius, 0)
        aGraphicsPath.AddArc(GetRightUpper(), 270, 90)
        aGraphicsPath.AddLine(Width, Radius, Width, Height - Radius)
        aGraphicsPath.AddArc(GetRightLower(), 0, 90)
        aGraphicsPath.AddLine(Width - Radius, Height, Radius, Height)
        aGraphicsPath.AddArc(GetLeftLower(), 90, 90)
        aGraphicsPath.AddLine(0, Height - Radius, 0, Radius)
        aGraphicsPath.CloseFigure()

        Me.Region = New Region(aGraphicsPath)

    End Sub


    Private Function GetLeftUpper() As Rectangle
        Return New Rectangle(0, 0, Me._radius, Me._radius)
    End Function

    Private Function GetRightUpper() As Rectangle
        Return New Rectangle((Width - 1) - Me._radius, 0, Me._radius, Me._radius)
    End Function

    Private Function GetRightLower() As Rectangle
        Return New Rectangle((Width - 1) - Me._radius, (Height - 1) - Me._radius, Me._radius, Me._radius)
    End Function

    Private Function GetLeftLower() As Rectangle
        Return New Rectangle(0, (Height - 1) - Me._radius, Me._radius, Me._radius)
    End Function

End Class
