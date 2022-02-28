Public Class ProgressController


    Private _parentForm As Form


    Private aProgressForm As Form
    Delegate Sub InvokeDelegate()




    Public Sub New(ByVal parentForm As Form)
        Me._parentForm = parentForm
    End Sub


    Public Sub ShowProgressWin()
        Me._parentForm.Enabled = False

        'StartThread()
        ' http://msdn.microsoft.com/en-us/library/vstudio/system.componentmodel.backgroundworker
        Dim aThread As System.Threading.Thread = New Threading.Thread(AddressOf Task_form)
        aThread.SetApartmentState(Threading.ApartmentState.STA)
        aThread.Start()

        System.Threading.Thread.Sleep(1000)

    End Sub



    Public Sub CloseProgressWin()
        'Me.BackgroundWorker1.CancelAsync()
        'Application.DoEvents()
        Try
            If Not aProgressForm Is Nothing Then
                aProgressForm.BeginInvoke(New InvokeDelegate(AddressOf aProgressForm.Close))
            End If
            Me._parentForm.Enabled = True
            Me._parentForm.Refresh()
            'Application.DoEvents()

        Catch ex As Exception
            System.Threading.Thread.Sleep(2000)
            closeProgressWin()
        End Try
    End Sub


    Public Sub Task_form()
        aProgressForm = New ProgressForm(Me._parentForm.Location, Me._parentForm.Size) ' Must be created on this thread!
        Application.Run(aProgressForm)
    End Sub


    
End Class
