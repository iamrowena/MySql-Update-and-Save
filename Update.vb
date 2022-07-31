/** This code is for updating the inputted values in the database through Visual Studio */

//Declare variable in the Public Class
Imports MySql.Data.MySqlClient
Public Class Form1
    Dim CONNECT As MySqlConnection
    Dim CONSTRING As String = "data source = localhost; user id = root; database = votingsystem_pacadalhin"
    Dim CMD As MySqlCommand
    Dim DA As MySqlDataAdapter
    Dim DS As DataSet
    Dim itemcoll(999) As String

    
 
    Private Sub Update_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles update_Button.Click
        Try
//Code for the Update Buttom
            CONNECT = New MySqlConnection(CONSTRING)
            CONNECT.Open()
            Dim SQL As String = "Update voters set First_Name = '" & TextBox2.Text & "',  Last_Name = '" & TextBox3.Text & "', Middle_Name = '" & TextBox4.Text & "', Course = '" & TextBox5.Text & "', Year_Section = '" & TextBox6.Text & "',  EMail = '" & TextBox7.Text & "' where Student_Number = '" & Studentnum.Text & "'"
            CMD = New MySqlCommand(SQL, CONNECT)
            Dim i As Integer = CMD.ExecuteNonQuery
            If i <> 0 Then
                MsgBox("Record Updated", vbInformation, "Admin")
            Else
                MsgBox("Record Cannot Be Updated", vbInformation, "Admin")
            End If
            Call LOADLV()
            CONNECT.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
 
//Codes for the ListView
Public Sub LOADLV()
        Try
            ListView1.Items.Clear()
            CONNECT = New MySqlConnection(CONSTRING)
            CONNECT.Open()
            Dim SQL As String = "select * from voters"
            CMD = New MySqlCommand(SQL, CONNECT)
            DA = New MySqlDataAdapter(CMD)
            DS = New DataSet
            DA.Fill(DS, "Tables")
            For r = 0 To DS.Tables(0).Rows.Count - 1
                For c = 0 To DS.Tables(0).Columns.Count - 1
                    itemcoll(c) = DS.Tables(0).Rows(r)(c).ToString
                Next
                Dim lvitm As New ListViewItem(itemcoll)
                ListView1.Items.Add(lvitm)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        CONNECT.Close()
    End Sub
