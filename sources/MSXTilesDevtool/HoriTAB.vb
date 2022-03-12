Public Class HoriTAB

    Private _selectedTab As TAB_NAME = TAB_NAME.SCREEN


    ' EVENTs ###########################################################################################################################

    Public Event TabChanged(ByVal index As HoriTAB.TAB_NAME)

    ' ####################################################################################################################### END EVENTs



    Public Shadows Enum TAB_NAME As Integer
        SCREEN
        MAP
        TILESET
        SPRITESET
        OAM
    End Enum


    Public ReadOnly Property SelectTab As TAB_NAME
        Get
            Return _selectedTab
        End Get
    End Property



    Private Sub VerttiTAB_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetTab(TAB_NAME.SCREEN)
    End Sub



    Public Sub SetTab(index As TAB_NAME)

        ShowTab(_selectedTab, False)

        ShowTab(index, True)

        _selectedTab = index

    End Sub



    Private Sub ShowTab(index As TAB_NAME, state As Boolean)

        Dim offset As Integer = 1

        If state Then
            offset = 0
        End If

        Select Case index
            Case TAB_NAME.SCREEN
                Tab0Button.ImageIndex = 0 + offset

            Case TAB_NAME.MAP
                Tab1Button.ImageIndex = 2 + offset

            Case TAB_NAME.TILESET
                Tab2Button.ImageIndex = 4 + offset

            Case TAB_NAME.SPRITESET
                Tab3Button.ImageIndex = 6 + offset

            Case TAB_NAME.OAM
                Tab4Button.ImageIndex = 8 + offset

        End Select

    End Sub



    Private Sub TabButton_Click(sender As Object, e As EventArgs) Handles Tab0Button.Click, Tab1Button.Click, Tab2Button.Click, Tab3Button.Click, Tab4Button.Click
        Dim aButton As Button = sender
        SetTab(aButton.TabIndex)
        RaiseEvent TabChanged(aButton.TabIndex)
    End Sub


End Class
