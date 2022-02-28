Imports System.Windows.Forms
Imports System.Xml



Public Class WizardDialog

    'Private ConfigPath As String

    Private WizardStep As Integer = 0

    Private WizardControl As Windows.Forms.Control

    Private StepPanel As System.Windows.Forms.Panel
    Private NameTextBox As System.Windows.Forms.TextBox

    Private RadioItemsList As ArrayList



    Public Steps As New SortedList



    Public Sub New(ByVal path As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LoadConfig(path)
    End Sub



    Public Sub New(ByVal _steps As SortedList)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Steps = _steps

    End Sub



    Private Sub WizardDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'setQuestion1()

        ShowStep(Me.WizardStep)

    End Sub



    Public Function GetData() As ArrayList
        Dim dataList As New ArrayList
        For Each aStep As WizardStep In Me.Steps.Values
            If aStep.Type < 3 Then
                dataList.Add(aStep.TextValue)
            Else
                dataList.Add(aStep.Selected)
            End If
        Next
        Return dataList
    End Function



    Public Function LoadConfig(ByVal path As String) As Boolean

        Dim result As Boolean = False

        Try
            Dim aXmlDoc As New XmlDocument
            Dim rootNode As XmlNode
            Dim aNode As XmlNode
            Dim aNodeList As XmlNodeList
            Dim subNodeList As XmlNodeList

            'Dim aValue As String
            'Dim anotherValue As String

            Dim stepID As Integer
            Dim stepType As GUI.Controls.WizardStep.STEP_TYPE
            Dim stepTitle As String = ""
            Dim stepDefvalue As String

            Dim itemsList As SortedList
            Dim itemID As Integer
            Dim itemValue As String

            Dim tmpStep As WizardStep


            'Dim ConfigFileAdress As String = System.AppDomain.CurrentDomain.BaseDirectory + Me.ConfigFileName


            If System.IO.File.Exists(path) Then

                aXmlDoc.Load(path)

                rootNode = aXmlDoc.SelectSingleNode("wizard")
                If Not rootNode Is Nothing Then

                    aNodeList = rootNode.SelectNodes("step")
                    If aNodeList Is Nothing Then
                        'Me.RecentProjects = New RecentProjectsList

                    Else

                        For Each nodeStep As XmlNode In aNodeList

                            aNode = nodeStep.SelectSingleNode("@id")
                            If aNode Is Nothing Then
                                stepID = -1
                            Else
                                stepID = CInt(aNode.InnerText)
                            End If

                            aNode = nodeStep.SelectSingleNode("@type")
                            If aNode Is Nothing Then
                                stepID = -1
                            Else
                                stepType = CInt(aNode.InnerText)
                            End If


                            aNode = nodeStep.SelectSingleNode("@title")
                            If aNode Is Nothing Then
                                stepID = -1
                            Else
                                stepTitle = aNode.InnerText
                            End If

                            aNode = nodeStep.SelectSingleNode("@defValue")
                            If aNode Is Nothing Then
                                stepDefvalue = ""
                            Else
                                stepDefvalue = aNode.InnerText
                            End If

                            If stepType > 2 Then

                                subNodeList = nodeStep.SelectNodes("item")
                                If Not subNodeList Is Nothing Then
                                    itemsList = New SortedList

                                    For Each nodeItem As XmlNode In subNodeList
                                        aNode = nodeItem.SelectSingleNode("@id")
                                        If aNode Is Nothing Then
                                            itemID = -1
                                        Else
                                            itemID = CInt(aNode.InnerText)
                                        End If

                                        aNode = nodeItem.SelectSingleNode("@value")
                                        If aNode Is Nothing Then
                                            itemValue = ""
                                        Else
                                            itemValue = aNode.InnerText
                                        End If

                                        itemsList.Add(itemID, itemValue)
                                    Next

                                End If

                            End If

                            'itemIndex = CInt(aNodeItem.Attributes.GetNamedItem("index").InnerText)
                            'aValue = aNodeItem.Attributes.GetNamedItem("path").InnerText

                            If stepID >= 0 Then

                                If stepType < 3 Then
                                    tmpStep = New WizardStep(stepID, stepType, stepTitle, stepDefvalue)
                                Else
                                    tmpStep = New WizardStep(stepID, stepType, stepTitle, itemsList, CInt(stepDefvalue)) 'stepID, stepType, stepTitle, itemsList, CInt(stepDefvalue))
                                End If

                                Me.Steps.Add(stepID, tmpStep)
                            End If

                        Next

                    End If

                    result = True
                Else
                    result = False
                End If

            Else
                result = False
            End If


        Catch ex As Exception
            ' error! No se ha podido cargar la configuración
            result = False
        End Try

        Return result

    End Function



    'Private Sub RunWizard()
    '    For Each aStep As WizardStep In Me.Steps
    '        Me.WizardStep = aStep.Position

    '    Next
    'End Sub




    Private Sub ShowStep(ByVal stepNumber As Integer)

        Dim _step As WizardStep

        Me.StepLabel.Text = CStr(stepNumber + 1) + "/" + CStr(Me.Steps.Count + 1)
        Me.InfoLabel.Text = ""




        ' controla la visualizacion del boton de retroceso, dependiendo del paso en curso
        If Me.WizardStep = 0 Then
            Me.BackButton.Enabled = False
        Else
            Me.BackButton.Enabled = True
        End If



        If stepNumber > (Me.Steps.Count - 1) Then
            'last step, show all data for confirm
            Me.TitleLabel.Text = "Confirm Data"
            Me.NextButton.Text = "Make Project"
            Me.IconPictureBox.Image = Me.IconImageList.Images.Item(6) ' 6 = confirm icon

            ' #############################################################################
            ' generate a list with all data values
            Dim textList As New ArrayList
            For Each aStep As WizardStep In Me.Steps.Values
                If aStep.Type < 3 Then
                    textList.Add(aStep.TextValue)
                Else
                    textList.Add(aStep.ItemsList.Item(aStep.Selected))
                End If
            Next
            ShowTextList(textList)
            Me.NextButton.Select()
            ' #############################################################################

        Else
            _step = Me.Steps.Item(stepNumber)

            Me.NextButton.Text = "Next"
            Me.TitleLabel.Text = _step.Title
            Me.IconPictureBox.Image = Me.IconImageList.Images.Item(_step.Type)

            Select Case _step.Type
                Case GUI.Controls.WizardStep.STEP_TYPE.TEXT
                    ShowEntryText(_step.TextValue)

                Case GUI.Controls.WizardStep.STEP_TYPE.FILEPATH



                Case GUI.Controls.WizardStep.STEP_TYPE.FOLDERPATH



                Case GUI.Controls.WizardStep.STEP_TYPE.RADIOLIST
                    ShowItemsList(_step.ItemsList, _step.Selected)


                Case GUI.Controls.WizardStep.STEP_TYPE.COMBOLIST


                Case GUI.Controls.WizardStep.STEP_TYPE.CHECKLIST


            End Select

        End If

    End Sub



    



    Private Sub SetData()
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Dim _step As WizardStep = Me.Steps.Item(Me.WizardStep)

        Select Case _step.Type
            Case GUI.Controls.WizardStep.STEP_TYPE.TEXT
                _step.TextValue = Me.NameTextBox.Text
            Case GUI.Controls.WizardStep.STEP_TYPE.FILEPATH
                _step.TextValue = Me.NameTextBox.Text
            Case GUI.Controls.WizardStep.STEP_TYPE.FOLDERPATH
                _step.TextValue = Me.NameTextBox.Text
            Case GUI.Controls.WizardStep.STEP_TYPE.RADIOLIST
                _step.Selected = GetRadioButtonChecked()
            Case GUI.Controls.WizardStep.STEP_TYPE.COMBOLIST

            Case GUI.Controls.WizardStep.STEP_TYPE.CHECKLIST

        End Select

    End Sub




    Private Function GetRadioButtonChecked() As Integer
        Dim checked As Integer = 0

        For Each item As RadioButton In Me.RadioItemsList
            If item.Checked = True Then
                checked = CInt(item.Name)
                Exit For
            End If
        Next

        Return checked
    End Function



    Private Sub NextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextButton.Click

        If Me.WizardStep > (Me.Steps.Count - 1) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        Else
            SetData()

            If Me.WizardStep < (Me.Steps.Count + 1) Then
                Me.WizardStep += 1
                Me.ShowStep(Me.WizardStep)
            End If
        End If
    End Sub



    Private Sub BackButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackButton.Click

        If Me.WizardStep < Me.Steps.Count Then
            SetData()
        End If

        If Me.WizardStep > 0 Then
            Me.WizardStep -= 1
            Me.ShowStep(Me.WizardStep)
        End If
    End Sub



    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub



    Private Sub ShowEntryText(ByVal value As String)

        If Not Me.WizardControl Is Nothing Then
            Me.WizardControl.Dispose()
        End If

        Me.StepPanel = New System.Windows.Forms.Panel
        Me.NameTextBox = New System.Windows.Forms.TextBox

        Me.SuspendLayout()

        '
        'StepPanel
        '
        'Me.StepPanel.Controls.Add(Me.RadioButton1)
        Me.StepPanel.Location = New System.Drawing.Point(38, 12)
        Me.StepPanel.Name = "StepPanel"
        Me.StepPanel.Size = New System.Drawing.Size(350, 145)
        Me.StepPanel.TabIndex = 0

        '
        'NameTextBox
        '
        NameTextBox.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameTextBox.Location = New System.Drawing.Point(20, 30)
        NameTextBox.MaxLength = 32
        NameTextBox.Name = "NameTextBox"
        NameTextBox.Size = New System.Drawing.Size(300, 31)
        NameTextBox.TabIndex = 1
        NameTextBox.Text = value

        Me.StepPanel.Controls.Add(Me.NameTextBox)
        Me.WizardPanel.Controls.Add(Me.StepPanel)

        Me.ResumeLayout(False)
        Me.PerformLayout()

        NameTextBox.Select()

        Me.WizardControl = Me.StepPanel

    End Sub



    Private Sub ShowItemsList(ByVal _list As SortedList, ByVal itemSelected As Integer)

        If Not Me.WizardControl Is Nothing Then
            Me.WizardControl.Dispose()
        End If

        'Dim itemNumber As Integer = 0
        Dim _RadioButton As System.Windows.Forms.RadioButton
        Me.StepPanel = New System.Windows.Forms.Panel

        RadioItemsList = New ArrayList

        Me.SuspendLayout()

        '
        'StepPanel
        '
        'Me.StepPanel.Controls.Add(Me.RadioButton1)
        Me.StepPanel.Location = New System.Drawing.Point(38, 12)
        Me.StepPanel.Name = "StepPanel"
        Me.StepPanel.Size = New System.Drawing.Size(350, 145)
        Me.StepPanel.TabIndex = 0

        For Each id As Integer In _list.Keys
            _RadioButton = GetRadioButtonItem(id, _list.Item(id))
            Me.StepPanel.Controls.Add(_RadioButton)
            RadioItemsList.Add(_RadioButton)
        Next

        Me.WizardPanel.Controls.Add(Me.StepPanel)

        Me.ResumeLayout(False)
        Me.PerformLayout()

        Me.WizardControl = Me.StepPanel

        'select item
        If itemSelected > Me.RadioItemsList.Count Then
            itemSelected = 0
        End If
        'CType(Me.RadioItemsList.Item(itemSelected), RadioButton).Checked = True
        CType(Me.RadioItemsList.Item(itemSelected), RadioButton).Select()


    End Sub



    Private Sub ShowTextList(ByVal textList As ArrayList)

        Dim itemNumber As Integer = 0
        Dim tmpText As String = ""
        Dim NameLabel = New System.Windows.Forms.Label


        If Not Me.WizardControl Is Nothing Then
            Me.WizardControl.Dispose()
        End If


        Me.StepPanel = New System.Windows.Forms.Panel

        RadioItemsList = New ArrayList

        Me.SuspendLayout()

        '
        'StepPanel
        '
        'Me.StepPanel.Controls.Add(Me.RadioButton1)
        Me.StepPanel.Location = New System.Drawing.Point(38, 12)
        Me.StepPanel.Name = "StepPanel"
        Me.StepPanel.Size = New System.Drawing.Size(350, 145)
        Me.StepPanel.TabIndex = 0

        NameLabel.Dock = System.Windows.Forms.DockStyle.Fill
        NameLabel.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameLabel.ForeColor = System.Drawing.Color.Black
        NameLabel.Location = New System.Drawing.Point(0, 0)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(460, 150)
        NameLabel.TabIndex = 7

        Me.StepPanel.Controls.Add(NameLabel)

        For Each itemName As String In textList
            '_RadioButton = GetRadioButtonItem(itemNumber, itemName)
            tmpText += CStr(itemNumber + 1) + " - " + itemName + Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
            itemNumber += 1
        Next

        NameLabel.Text = tmpText '"1. pepe" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2. manol" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3 kilo"


        Me.WizardPanel.Controls.Add(Me.StepPanel)

        Me.ResumeLayout(False)
        Me.PerformLayout()

        Me.WizardControl = Me.StepPanel

    End Sub



    Private Function GetRadioButtonItem(ByVal numItem As Integer, ByVal name As String) As System.Windows.Forms.RadioButton
        Dim RadioButton1 As New System.Windows.Forms.RadioButton

        RadioButton1.AutoSize = True
        RadioButton1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        RadioButton1.Location = New System.Drawing.Point(1, numItem * 30)
        RadioButton1.Name = CStr(numItem)
        RadioButton1.Size = New System.Drawing.Size(121, 27)
        RadioButton1.TabIndex = numItem
        RadioButton1.TabStop = True
        RadioButton1.Text = name
        RadioButton1.UseVisualStyleBackColor = True

        Return RadioButton1
    End Function


End Class