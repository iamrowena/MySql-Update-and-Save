// The code should be put in the button
//This code is for saving the inputted data of the user in the database - MySql

//Code for the Public Class
    Dim CONNECT As MySqlConnection
    Dim CONSTRING As String = "data source = localhost; user id = root; database = votingsystem_pacadalhin"
    Dim CMD As MySqlCommand
  
//Code for Save button
  
            CONNECT = New MySqlConnection(CONSTRING)
            CONNECT.Open()
            Dim SQL As String = "Insert INTO candidates (Candidate_Number, Full_name, Position, Partylist_number) values ( '" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & ComboBox1.Text & "', '" & TextBox3.Text & "')"
            CMD = New MySqlCommand(SQL, CONNECT)
            Dim i As Integer = CMD.ExecuteNonQuery
            If i <> 0 Then
                MsgBox("Record Saved", vbInformation, "Admin")
            Else
                MsgBox("Record Not Saved", vbInformation, "Admin")
            End If
            Call ShowD()
            CONNECT.Close()
        Catch ex As Exception
            MsgBox(ex.Message)          
  
