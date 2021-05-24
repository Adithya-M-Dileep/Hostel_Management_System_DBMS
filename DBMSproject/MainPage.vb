Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient

Public Class MainPage
    Dim connection As New MySqlConnection("server=127.0.0.1;user id=root;database=dbms")
    Dim command As New MySqlCommand
    Dim adapter As New MySqlDataAdapter
    Dim DT As New DataTable
    Dim dataReader As MySqlDataReader
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles leftPanel.Paint
        tableP.Visible = False

    End Sub


    'STUDENT info
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles student.Click
        ponbtn.Height = student.Height
        ponbtn.Top = student.Top
        studentsP.Visible = True
        roomsP.Visible = False
        furnitureP.Visible = False
        messP.Visible = False
        feesP.Visible = False
        hostelP.Visible = False
        messEmployeeP.Visible = False
        visitorsP.Visible = False
        tableP.Visible = False


    End Sub
    Private Sub stdClear_Click(sender As Object, e As EventArgs) Handles stdClear.Click
        stdId.Clear()
        stdName.Clear()
        fatName.Clear()
        stdRoomId.Clear()
        stdMobNumber.Clear()
        dob.Clear()

    End Sub

    Private Sub stdSearch_Click(sender As Object, e As EventArgs) Handles stdSearch.Click
        Try
            If stdId.Text = "" Then
                connection.Open()
                Dim att As String = stdName.Text
                tableP.Visible = True

                command = connection.CreateCommand()
                command.CommandType = CommandType.Text
                command.CommandText = "SELECT * FROM `student` WHERE Student_name LIKE '" & att & "%'"
                command.ExecuteNonQuery()
                DT = New DataTable()
                adapter = New MySqlDataAdapter(command)
                adapter.Fill(DT)
                DataGridView1.DataSource = DT
                connection.Close()
            Else
                Dim id As String = stdId.Text
                connection.Open()
                command = connection.CreateCommand()
                command.CommandType = CommandType.Text
                command.CommandText = "SELECT * FROM `student` WHERE `Student_id` =" & id
                command.ExecuteNonQuery()

                dataReader = command.ExecuteReader(CommandBehavior.CloseConnection)

                While dataReader.Read
                    stdName.Text = dataReader.GetString(1).ToString
                    fatName.Text = dataReader.GetString(2).ToString
                    stdRoomId.Text = dataReader.GetString(3).ToString
                    stdMobNumber.Text = dataReader.GetString(4).ToString
                    dob.Text = dataReader.GetString(5).ToString

                End While
                connection.Close()
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try

    End Sub
    Private Sub stdAdd_Click(sender As Object, e As EventArgs) Handles stdAdd.Click

        Try
            connection.Open()

            Dim att1 As Integer = CInt(stdId.Text)
            Dim att2 As String = stdName.Text
            Dim att3 As String = fatName.Text
            Dim att4 As String = CInt(stdRoomId.Text)
            Dim att5 As Integer = CInt(stdMobNumber.Text)
            Dim att6 As String = dob.Text


            command = New MySqlCommand
            command.CommandText = "INSERT INTO `student` (`Student_id`, `Room_id`, `Student_name`, `Student_fathername`, `Phone_number`, `DOB`) VALUES ('" & att1 & "', '" & att4 & "', '" & att2 & "', '" & att3 & "', '" & att5 & "', '" & att6 & "');"
            command.Connection = connection
            command.ExecuteNonQuery()

            'clear text box
            stdId.Clear()
            stdName.Clear()
            fatName.Clear()
            stdRoomId.Clear()
            stdMobNumber.Clear()
            dob.Clear()

            connection.Close()
            MessageBox.Show("Data inserted", "INSERTION")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try



    End Sub


    Private Sub stdUpdate_Click(sender As Object, e As EventArgs) Handles stdUpdate.Click
        Try
            connection.Open()

            Dim att1 As Integer = CInt(stdId.Text)
            Dim att2 As String = stdName.Text
            Dim att3 As String = fatName.Text
            Dim att4 As String = CInt(stdRoomId.Text)
            Dim att5 As Integer = CInt(stdMobNumber.Text)
            Dim att6 As String = dob.Text

            command = New MySqlCommand
            command.CommandText = "UPDATE `student` SET `Room_id`='" & att4 & "',`Student_name`='" & att2 & "',`Student_fathername`='" & att3 & "',`Phone_number`='" & att5 & "',`DOB`='" & att6 & "' WHERE `Student_id`='" & att1 & "'"
            command.Connection = connection
            command.ExecuteNonQuery()

            'clear text box
            stdId.Clear()
            stdName.Clear()
            fatName.Clear()
            stdRoomId.Clear()
            stdMobNumber.Clear()
            dob.Clear()
            connection.Close()
            MessageBox.Show("Data Updated", "UPDATION")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try


    End Sub
    Private Sub stdDelete_Click(sender As Object, e As EventArgs) Handles stdDelete.Click
        Try
            connection.Open()

            Dim att1 As Integer = CInt(stdId.Text)
            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "DELETE FROM `student` WHERE Student_id=" & att1
            command.ExecuteNonQuery()

            'clear text box
            connection.Close()
            MessageBox.Show("Data Deleted", "DELETION")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub
    Private Sub stdView_Click(sender As Object, e As EventArgs) Handles stdView.Click
        tableP.Visible = True
        Try
            connection.Open()
            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT * FROM `student`"
            command.ExecuteNonQuery()
            DT = New DataTable()
            adapter = New MySqlDataAdapter(command)
            adapter.Fill(DT)
            DataGridView1.DataSource = DT
            connection.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub







    'ROOM INFO
    Private Sub Rooms_Click(sender As Object, e As EventArgs) Handles Rooms.Click
        ponbtn.Height = Rooms.Height
        ponbtn.Top = Rooms.Top
        studentsP.Visible = False
        roomsP.Visible = True
        furnitureP.Visible = False
        messP.Visible = False
        feesP.Visible = False
        hostelP.Visible = False
        messEmployeeP.Visible = False
        visitorsP.Visible = False
        tableP.Visible = False
    End Sub
    Private Sub rmClear_Click(sender As Object, e As EventArgs) Handles rmClear.Click
        rmId.Clear()
        rmCap.Clear()
        rmFurId.Clear()
        rmBdNum.Clear()

    End Sub
    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles rmSearch.Click
        Try
            Dim id As Integer = CInt(rmId.Text)
            connection.Open()
            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT * FROM `room` WHERE Room_id=" & id
            command.ExecuteNonQuery()

            dataReader = command.ExecuteReader(CommandBehavior.CloseConnection)

            While dataReader.Read
                rmCap.Text = dataReader.GetString(1).ToString
                rmFurId.Text = dataReader.GetString(2).ToString
                rmBdNum.Text = dataReader.GetString(3).ToString

            End While

            connection.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub
    Private Sub rmAdd_Click(sender As Object, e As EventArgs) Handles rmAdd.Click
        Try
            connection.Open()

            Dim att1 As Integer = rmId.Text
            Dim att2 As Integer = CInt(rmCap.Text)
            Dim att3 As Integer = rmFurID.Text
            Dim att4 As Integer = rmBdNum.Text
            command = New MySqlCommand
            command.CommandText = "INSERT INTO `room`(`Room_id`, `Capacity`, `Furniture_id`, `Building_number`) VALUES ('" & att1 & "','" & att2 & "','" & att3 & "','" & att4 & "' )"
            command.Connection = connection
            command.ExecuteNonQuery()

            'clear text box
            rmId.Clear()
            rmCap.Clear()
            rmFurId.Clear()
            rmBdNum.Clear()

            connection.Close()
            MessageBox.Show("Data inserted", "INSERTION")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try


    End Sub


    Private Sub rmUpdate_Click(sender As Object, e As EventArgs) Handles rmUpdate.Click
        Try
            connection.Open()

            Dim att1 As Integer = CInt(rmId.Text)
            Dim att2 As Integer = CInt(rmCap.Text)
            Dim att3 As String = CInt(rmFurId.Text)
            Dim att4 As String = CInt(rmBdNum.Text)
            command = New MySqlCommand
            command.CommandText = "UPDATE `room` SET `Capacity`='" & att2 & "',`Furniture_id`='" & att3 & "',`Building_number`='" & att4 & "' WHERE `Room_id`='" & att1 & "'"
            command.Connection = connection
            command.ExecuteNonQuery()

            'clear text box
            rmId.Clear()
            rmCap.Clear()
            rmFurId.Clear()
            rmBdNum.Clear()

            connection.Close()
            MessageBox.Show("Data updated", "UPDATION")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try


    End Sub

    Private Sub rmDelete_Click(sender As Object, e As EventArgs) Handles rmDelete.Click
        Try
            connection.Open()

            Dim att1 As Integer = CInt(rmId.Text)

            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "DELETE FROM `room` WHERE Room_id=" & att1
            command.ExecuteNonQuery()

            'clear text box


            connection.Close()
            MessageBox.Show("Data Deleted", "DELETION")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub
    Private Sub rmView_Click(sender As Object, e As EventArgs) Handles rmView.Click
        tableP.Visible = True
        Try
            connection.Open()
            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT * FROM `room`"
            command.ExecuteNonQuery()
            DT = New DataTable()
            adapter = New MySqlDataAdapter(command)
            adapter.Fill(DT)
            DataGridView1.DataSource = DT
            connection.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub







    'FURNITURE INFO

    Private Sub Furniture_Click(sender As Object, e As EventArgs) Handles Furniture.Click
        ponbtn.Height = Furniture.Height
        ponbtn.Top = Furniture.Top
        studentsP.Visible = False
        roomsP.Visible = False
        furnitureP.Visible = True
        messP.Visible = False
        feesP.Visible = False
        hostelP.Visible = False
        messEmployeeP.Visible = False
        visitorsP.Visible = False
        tableP.Visible = False
    End Sub
    Private Sub fClear_Click(sender As Object, e As EventArgs) Handles fClear.Click

        fType.Clear()
        fId.Clear()

    End Sub
    Private Sub fSearch_Click(sender As Object, e As EventArgs) Handles fSearch.Click
        Try

            If fId.Text = "" Then
                connection.Open()
                Dim type As String = fType.Text
                tableP.Visible = True

                command = connection.CreateCommand()
                command.CommandType = CommandType.Text
                command.CommandText = "SELECT * FROM `furniture` WHERE Furniture_type LIKE '" & type & "%'"
                command.ExecuteNonQuery()
                DT = New DataTable()
                adapter = New MySqlDataAdapter(command)
                adapter.Fill(DT)
                DataGridView1.DataSource = DT
                connection.Close()
            Else
                connection.Open()

                Dim id As Integer = CInt(fId.Text)

                command = connection.CreateCommand()
                command.CommandType = CommandType.Text
                command.CommandText = "SELECT * FROM `furniture` where Furniture_id =" & id
                command.ExecuteNonQuery()

                dataReader = command.ExecuteReader(CommandBehavior.CloseConnection)

                While dataReader.Read
                    fType.Text = dataReader.GetString(1).ToString

                End While
                connection.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub
    Private Sub fAdd_Click(sender As Object, e As EventArgs) Handles fAdd.Click
        Try
            connection.Open()

            Dim att1 As String = CInt(fId.Text)
            Dim att2 As String = fType.Text


            command = New MySqlCommand
            command.CommandText = "INSERT INTO `furniture`(`Furniture_id`, `Furniture_type`) VALUES ('" & att1 & "','" & att2 & "')"
            command.Connection = connection
            command.ExecuteNonQuery()

            'clear text box

            fType.Clear()
            fId.Clear()

            connection.Close()
            MessageBox.Show("Data inserted", "INSERTION")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try

    End Sub
    Private Sub fUpdate_Click(sender As Object, e As EventArgs) Handles fUpdate.Click
        Try
            connection.Open()

            Dim att1 As String = CInt(fId.Text)
            Dim att2 As String = fType.Text

            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "UPDATE `furniture` SET Furniture_type='" & att2 & "' WHERE Furniture_id=" & att1
            command.ExecuteNonQuery()

            'clear text box

            fType.Clear()
            fId.Clear()

            MessageBox.Show("Data Updated", "UPDATE")
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub
    Private Sub fDelete_Click(sender As Object, e As EventArgs) Handles fDelete.Click
        Try
            connection.Open()

            Dim att1 As String = CInt(fId.Text)

            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "DELETE FROM `furniture` WHERE Furniture_id=" & att1
            command.ExecuteNonQuery()

            'clear text box

            fType.Clear()
            fId.Clear()

            MessageBox.Show("Data Deleted", "DELETION")

            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub
    Private Sub fView_Click(sender As Object, e As EventArgs) Handles fView.Click

        Try
            tableP.Visible = True
            connection.Open()
            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT * FROM `furniture`"
            command.ExecuteNonQuery()
            DT = New DataTable()
            adapter = New MySqlDataAdapter(command)
            adapter.Fill(DT)
            DataGridView1.DataSource = DT
            connection.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub





    'MESS INFO

    Private Sub Mess_Click(sender As Object, e As EventArgs) Handles Mess.Click
        ponbtn.Height = Mess.Height
        ponbtn.Top = Mess.Top
        studentsP.Visible = False
        roomsP.Visible = False
        furnitureP.Visible = False
        messP.Visible = True
        feesP.Visible = False
        hostelP.Visible = False
        messEmployeeP.Visible = False
        visitorsP.Visible = False
        tableP.Visible = False
    End Sub
    Private Sub mClear_Click(sender As Object, e As EventArgs) Handles mClear.Click
        mIncId.Clear()
        mExp.Clear()
        mTime.Clear()

    End Sub
    Private Sub mSearch_Click(sender As Object, e As EventArgs) Handles mSearch.Click
        Try
            Dim id As Integer = CInt(mIncId.Text)
            connection.Open()
            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT * FROM `mess` where Mess_incharge =" & id
            command.ExecuteNonQuery()

            dataReader = command.ExecuteReader(CommandBehavior.CloseConnection)

            While dataReader.Read
                mExp.Text = dataReader.GetString(1).ToString
                mTime.Text = dataReader.GetString(2).ToString
            End While

            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub

    Private Sub mAdd_Click(sender As Object, e As EventArgs) Handles mAdd.Click
        Try
            connection.Open()

            Dim att1 As Integer = CInt(mIncId.Text)
            Dim att2 As String = CInt(mExp.Text)
            Dim att3 As String = mTime.Text

            command = New MySqlCommand
            command.CommandText = "INSERT INTO `mess`(`Mess_incharge`, `Monthly_expenses`, `Mess_timings`) VALUES ('" & att1 & "','" & att2 & "','" & att3 & "')"
            command.Connection = connection
            command.ExecuteNonQuery()
            'clear text box
            mIncId.Clear()
            mExp.Clear()
            mTime.Clear()
            connection.Close()
            MessageBox.Show("Data inserted", "INSERTION")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try


    End Sub
    Private Sub mUpdate_Click(sender As Object, e As EventArgs) Handles mUpdate.Click
        Try
            connection.Open()

            Dim att1 As Integer = CInt(mIncId.Text)
            Dim att2 As Integer = CInt(mExp.Text)
            Dim att3 As String = mTime.Text

            command = New MySqlCommand
            command.CommandText = "UPDATE `mess` SET `Monthly_expenses`='" & att2 & "',`Mess_timings`='" & att3 & "' WHERE `Mess_incharge`='" & att1 & "'"
            command.Connection = connection
            command.ExecuteNonQuery()
            'clear text box
            mIncId.Clear()
            mExp.Clear()
            mTime.Clear()
            connection.Close()
            MessageBox.Show("Data updated", "UPDATION")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try


    End Sub
    Private Sub mDelete_Click(sender As Object, e As EventArgs) Handles mDelete.Click
        Try
            connection.Open()
            Dim att1 As Integer = CInt(mIncId.Text)

            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "DELETE FROM `mess` WHERE Mess_incharge=" & att1
            command.ExecuteNonQuery()

            'clear text box
            mIncId.Clear()
            mExp.Clear()
            mTime.Clear()

            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub
    Private Sub mView_Click(sender As Object, e As EventArgs) Handles mView.Click
        tableP.Visible = True
        Try
            connection.Open()
            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT * FROM `mess`"
            command.ExecuteNonQuery()
            DT = New DataTable()
            adapter = New MySqlDataAdapter(command)
            adapter.Fill(DT)
            DataGridView1.DataSource = DT
            connection.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub







    'FEES INFO
    Private Sub Fees_Click(sender As Object, e As EventArgs) Handles Fees.Click
        ponbtn.Height = Fees.Height
        ponbtn.Top = Fees.Top
        studentsP.Visible = False
        roomsP.Visible = False
        furnitureP.Visible = False
        messP.Visible = False
        feesP.Visible = True
        hostelP.Visible = False
        messEmployeeP.Visible = False
        visitorsP.Visible = False
        tableP.Visible = False
    End Sub
    Private Sub feeClear_Click(sender As Object, e As EventArgs) Handles feeClear.Click
        feeMonth.Clear()
        feeStatus.Clear()
        feeStdId.Clear()

    End Sub
    Private Sub feeSearch_Click(sender As Object, e As EventArgs) Handles feeSearch.Click

        'SOMEThing is fishy

        Try
            Dim id As Integer = CInt(feeStdId.Text)
            connection.Open()
            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT * FROM `fees` where Student_id =" & id
            command.ExecuteNonQuery()

            dataReader = command.ExecuteReader(CommandBehavior.CloseConnection)

            While dataReader.Read
                feeMonth.Text = dataReader.GetString(1).ToString
                feeStatus.Text = dataReader.GetString(2).ToString

            End While

            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()

        End Try
    End Sub

    Private Sub feeAdd_Click(sender As Object, e As EventArgs) Handles feeAdd.Click
        Try
            connection.Open()

            Dim att1 As String = feeMonth.Text
            Dim att2 As String = feeStatus.Text
            Dim att3 As String = CInt(feeStdId.Text)

            command = New MySqlCommand
            command.CommandText = "INSERT INTO `fees`(`Fee_month`, `Fee_status`, `Student_id`) VALUES ('" & att1 & "','" & att2 & "','" & att3 & "')"
            command.Connection = connection
            command.ExecuteNonQuery()

            'clear text box
            feeMonth.Clear()
            feeStatus.Clear()
            feeStdId.Clear()

            connection.Close()
            MessageBox.Show("Data inserted", "INSERTION")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try


    End Sub
    Private Sub feeUpdate_Click(sender As Object, e As EventArgs) Handles feeUpdate.Click
        Try
            connection.Open()

            Dim att1 As String = feeMonth.Text
            Dim att2 As String = feeStatus.Text
            Dim att3 As String = CInt(feeStdId.Text)

            command = New MySqlCommand
            command.CommandText = "UPDATE `fees` SET Fee_month='" & att1 & "',Fee_status='" & att2 & "' WHERE Student_id=" & att3

            command.Connection = connection
            command.ExecuteNonQuery()

            'clear text box
            feeMonth.Clear()
            feeStatus.Clear()
            feeStdId.Clear()

            connection.Close()
            MessageBox.Show("Data Updated", "UPDATION")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try


    End Sub
    Private Sub feeDelete_Click(sender As Object, e As EventArgs) Handles feeDelete.Click
        Try
            connection.Open()

            Dim att1 As String = CInt(feeStdId.Text)

            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "DELETE FROM `fees` WHERE Student_id=" & att1
            command.ExecuteNonQuery()

            'clear text box
            feeMonth.Clear()
            feeStatus.Clear()
            feeStdId.Clear()

            MessageBox.Show("Data Deleted", "DELETION")
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub
    Private Sub feeView_Click(sender As Object, e As EventArgs) Handles feeView.Click
        tableP.Visible = True
        Try
            connection.Open()
            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT * FROM `fees`"
            command.ExecuteNonQuery()
            DT = New DataTable()
            adapter = New MySqlDataAdapter(command)
            adapter.Fill(DT)
            DataGridView1.DataSource = DT
            connection.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub






    'HOSTEL INFO
    Private Sub Hostel_Click(sender As Object, e As EventArgs) Handles Hostel.Click
        ponbtn.Height = Hostel.Height
        ponbtn.Top = Hostel.Top
        studentsP.Visible = False
        roomsP.Visible = False
        furnitureP.Visible = False
        messP.Visible = False
        feesP.Visible = False
        hostelP.Visible = True
        messEmployeeP.Visible = False
        visitorsP.Visible = False
        tableP.Visible = False
    End Sub
    Private Sub hoClear_Click(sender As Object, e As EventArgs) Handles hoClear.Click
        hoBdNum.Clear()
        hoNOR.Clear()
        hoNOS.Clear()
        hoAnnualExp.Clear()
        hoLocation.Clear()

    End Sub
    Private Sub hoSearch_Click(sender As Object, e As EventArgs) Handles hoSearch.Click
        Try
            Dim num As Integer = CInt(hoBdNum.Text)
            connection.Open()
            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT * FROM `hostel` where Building_number =" & num
            command.ExecuteNonQuery()

            dataReader = command.ExecuteReader(CommandBehavior.CloseConnection)

            While dataReader.Read
                hoNOR.Text = dataReader.GetString(1).ToString
                hoNOS.Text = dataReader.GetString(2).ToString
                hoAnnualExp.Text = dataReader.GetString(3).ToString
                hoLocation.Text = dataReader.GetString(4).ToString

            End While

            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub

    Private Sub hoAdd_Click(sender As Object, e As EventArgs) Handles hoAdd.Click
        Try
            connection.Open()

            Dim att1 As String = CInt(hoBdNum.Text)
            Dim att2 As String = CInt(hoNOR.Text)
            Dim att3 As String = CInt(hoNOS.Text)
            Dim att4 As String = CInt(hoAnnualExp.Text)
            Dim att5 As String = hoLocation.Text


            command = New MySqlCommand
            command.CommandText = "INSERT INTO `hostel`(`Building_number`, `Number_of_rooms`, `Number_of_students`, `Annual_expenses`, `Location`) VALUES ('" & att1 & "','" & att2 & "','" & att3 & "','" & att4 & "','" & att5 & "')"
            command.Connection = connection
            command.ExecuteNonQuery()

            'clear text box
            hoBdNum.Clear()
            hoNOR.Clear()
            hoNOS.Clear()
            hoAnnualExp.Clear()
            hoLocation.Clear()


            connection.Close()
            MessageBox.Show("Data Inserted", "INSERTION")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub
    Private Sub hoUpdate_Click(sender As Object, e As EventArgs) Handles hoUpdate.Click
        Try
            connection.Open()

            Dim att1 As Integer = CInt(hoBdNum.Text)
            Dim att2 As String = CInt(hoNOR.Text)
            Dim att3 As String = CInt(hoNOS.Text)
            Dim att4 As String = CInt(hoAnnualExp.Text)
            Dim att5 As String = hoLocation.Text

            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "UPDATE `hostel` SET `Number_of_rooms`='" & att2 & "',`Number_of_students`='" & att3 & "',`Annual_expenses`='" & att4 & "',`Location`='" & att5 & "' WHERE `Building_number`='" & att1 & "'"
            command.ExecuteNonQuery()

            'clear text box
            hoBdNum.Clear()
            hoNOR.Clear()
            hoNOS.Clear()
            hoAnnualExp.Clear()
            hoLocation.Clear()


            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub
    Private Sub hoDelete_Click(sender As Object, e As EventArgs) Handles hoDelete.Click
        Try
            connection.Open()
            Dim att1 As Integer = CInt(hoBdNum.Text)

            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "DELETE FROM `hostel` WHERE Building_number=" & att1
            command.ExecuteNonQuery()

            'clear text box
            hoBdNum.Clear()
            hoNOR.Clear()
            hoNOS.Clear()
            hoAnnualExp.Clear()
            hoLocation.Clear()

            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub
    Private Sub hoView_Click(sender As Object, e As EventArgs) Handles hoView.Click
        tableP.Visible = True
        Try
            connection.Open()
            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT * FROM `hostel`"
            command.ExecuteNonQuery()
            DT = New DataTable()
            adapter = New MySqlDataAdapter(command)
            adapter.Fill(DT)
            DataGridView1.DataSource = DT
            connection.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub





    'MESS EMPLOYEE INFO
    Private Sub MessEmp_Click(sender As Object, e As EventArgs) Handles MessEmp.Click
        ponbtn.Height = MessEmp.Height
        ponbtn.Top = MessEmp.Top
        studentsP.Visible = False
        roomsP.Visible = False
        furnitureP.Visible = False
        messP.Visible = False
        feesP.Visible = False
        hostelP.Visible = False
        messEmployeeP.Visible = True
        visitorsP.Visible = False
        tableP.Visible = False
    End Sub
    Private Sub empClear_Click(sender As Object, e As EventArgs) Handles empClear.Click
        empId.Clear()
        empName.Clear()
        empaddress.Clear()
        empSalary.Clear()
        empPhone.Clear()


    End Sub
    Private Sub empSearch_Click(sender As Object, e As EventArgs) Handles empSearch.Click
        Try
            Dim id As Integer = CInt(empId.Text)
            connection.Open()
            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT * FROM `mess_employee` where Employee_id =" & id
            command.ExecuteNonQuery()

            dataReader = command.ExecuteReader(CommandBehavior.CloseConnection)

            While dataReader.Read
                empName.Text = dataReader.GetString(1).ToString
                empaddress.Text = dataReader.GetString(2).ToString
                empSalary.Text = dataReader.GetString(3).ToString
                empPhone.Text = dataReader.GetString(4).ToString

            End While

            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub

    Private Sub empAdd_Click(sender As Object, e As EventArgs) Handles empAdd.Click
        'Try
        connection.Open()

            Dim att1 As Integer = CInt(empId.Text)
            Dim att2 As String = empName.Text
            Dim att3 As String = empaddress.Text
            Dim att4 As String = CInt(empSalary.Text)
        Dim att5 As Integer = CInt(empPhone.Text)

        command = New MySqlCommand
        command.CommandText = "INSERT INTO `mess_employee`(`Employee_id`, `Employee_name`, `Employee_Address`, `Employee_salary`, `Employee_phone_number`) VALUES ('" & att1 & "','" & att2 & "','" & att3 & "','" & att4 & "','" & att5 & "')"
        command.Connection = connection
            command.ExecuteNonQuery()

            'clear text box
            empId.Clear()
            empName.Clear()
            empaddress.Clear()
            empSalary.Clear()
        empPhone.Clear()

        connection.Close()
            MessageBox.Show("Data inserted", "INSERTION")
        'Catch ex As Exception
        'MessageBox.Show(ex.Message, "ERROR")
        'connection.Close()
        ' End Try

    End Sub
    Private Sub empUpdate_Click(sender As Object, e As EventArgs) Handles empUpdate.Click
        Try
            connection.Open()

            Dim att1 As Integer = CInt(empId.Text)
            Dim att2 As String = empName.Text
            Dim att3 As String = empaddress.Text
            Dim att4 As String = CInt(empSalary.Text)
            Dim att5 As Integer = CInt(empPhone.Text)

            command = New MySqlCommand
            command.CommandText = "UPDATE `mess_employee` SET `Employee_name`='" & att2 & "',`Employee_Address`='" & att3 & "',`Employee_salary`='" & att4 & "',`Employee_phone_number`='" & att5 & "' WHERE `Employee_id`='" & att1 & "'"

            command.Connection = connection
            command.ExecuteNonQuery()

            'clear text box
            empId.Clear()
            empName.Clear()
            empaddress.Clear()
            empSalary.Clear()
            empPhone.Clear()

            connection.Close()
            MessageBox.Show("Data Updated", "IUPDATION")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub

    Private Sub empDelete_Click(sender As Object, e As EventArgs) Handles empDelete.Click
        Try
            connection.Open()
            Dim att1 As Integer = CInt(empId.Text)

            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "DELETE FROM `mess_employee` WHERE Employee_id=" & att1
            command.ExecuteNonQuery()

            'clear text box
            empId.Clear()
            empName.Clear()
            empaddress.Clear()
            empSalary.Clear()
            empPhone.Clear()

            MessageBox.Show("Data Deleted", "DELETION")
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub
    Private Sub empView_Click(sender As Object, e As EventArgs) Handles empView.Click
        tableP.Visible = True
        Try
            connection.Open()
            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT * FROM `mess_employee`"
            command.ExecuteNonQuery()
            DT = New DataTable()
            adapter = New MySqlDataAdapter(command)
            adapter.Fill(DT)
            DataGridView1.DataSource = DT
            connection.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub





    'VISITOR INFO
    Private Sub Visitors_Click(sender As Object, e As EventArgs) Handles Visitors.Click
        ponbtn.Height = Visitors.Height
        ponbtn.Top = Visitors.Top
        studentsP.Visible = False
        roomsP.Visible = False
        furnitureP.Visible = False
        messP.Visible = False
        feesP.Visible = False
        hostelP.Visible = False
        messEmployeeP.Visible = False
        visitorsP.Visible = True
        tableP.Visible = False
    End Sub
    Private Sub vClear_Click(sender As Object, e As EventArgs) Handles vClear.Click
        vCnic.Clear()
        vStdId.Clear()
        vName.Clear()
        vTimeOut.Clear()
        vDate.Clear()
        vTimeIn.Clear()


    End Sub
    Private Sub vSearch_Click(sender As Object, e As EventArgs) Handles vSearch.Click
        Try
            If vCnic.Text = "" Then
                connection.Open()
                Dim att1 As Integer = CInt(vStdId.Text)
                tableP.Visible = True

                command = connection.CreateCommand()
                command.CommandType = CommandType.Text
                command.CommandText = "SELECT * FROM `visitor` WHERE Student_id LIKE '" & att1 & "'"
                command.ExecuteNonQuery()
                DT = New DataTable()
                adapter = New MySqlDataAdapter(command)
                adapter.Fill(DT)
                DataGridView1.DataSource = DT
                connection.Close()
            Else
                connection.Open()
                Dim att1 As Integer = CInt(vCnic.Text)
                command = connection.CreateCommand()
                command.CommandType = CommandType.Text
                command.CommandText = "SELECT * FROM `visitor` where CNIC = " & att1
                command.ExecuteNonQuery()

                dataReader = command.ExecuteReader(CommandBehavior.CloseConnection)

                While dataReader.Read
                    vStdId.Text = dataReader.GetString(1).ToString
                    vName.Text = dataReader.GetString(2).ToString
                    vTimeIn.Text = dataReader.GetString(3).ToString
                    vTimeOut.Text = dataReader.GetString(4).ToString
                    vDate.Text = dataReader.GetString(5).ToString

                End While

                connection.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub

    Private Sub vAdd_Click(sender As Object, e As EventArgs) Handles vAdd.Click
        Try
            connection.Open()

            Dim att1 As Integer = CInt(vCnic.Text)
            Dim att2 As String = CInt(vStdId.Text)
            Dim att3 As String = vName.Text
            Dim att4 As String = vTimeIn.Text
            Dim att5 As String = vTimeOut.Text
            Dim att6 As String = vDate.Text

            command = New MySqlCommand
            command.CommandText = "INSERT INTO `visitor`(`CNIC`, `Visitor_name`, `Time_in`, `Time_out`, `Date_of_visit`, `Student_id`) VALUES ('" & att1 & "','" & att3 & "','" & att4 & "','" & att5 & "','" & att6 & "','" & att2 & "')"
            command.Connection = connection
            command.ExecuteNonQuery()

            'clear text box
            vCnic.Clear()
            vStdId.Clear()
            vName.Clear()
            vTimeIn.Clear()
            vTimeOut.Clear()
            vDate.Clear()

            connection.Close()
            MessageBox.Show("Data inserted", "INSERTION")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try

    End Sub
    Private Sub Button1_Click_3(sender As Object, e As EventArgs) Handles vUpdate.Click
        Try
            connection.Open()

            Dim att1 As Integer = CInt(vCnic.Text)
            Dim att2 As String = CInt(vStdId.Text)
            Dim att3 As String = vName.Text
            Dim att4 As String = vTimeIn.Text
            Dim att5 As String = vTimeOut.Text
            Dim att6 As String = vDate.Text

            command = New MySqlCommand
            command.CommandText = "UPDATE `visitor` SET `Visitor_name`='" & att3 & "',`Time_in`='" & att4 & "',`Time_out`='" & att5 & "',`Date_of_visit`='" & att6 & "',`Student_id`='" & att2 & "' WHERE `CNIC`='" & att1 & "'"

            command.Connection = connection
            command.ExecuteNonQuery()

            'clear text box
            vCnic.Clear()
            vStdId.Clear()
            vName.Clear()
            vTimeIn.Clear()
            vTimeOut.Clear()
            vDate.Clear()

            connection.Close()
            MessageBox.Show("Data Updated", "UPDATION")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try


    End Sub
    Private Sub vDelete_Click(sender As Object, e As EventArgs) Handles vDelete.Click
        Try
            connection.Open()
            Dim att1 As Integer = CInt(vCnic.Text)

            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "DELETE FROM `visitor` WHERE CNIC=" & att1
            command.ExecuteNonQuery()

            'clear text box
            vCnic.Clear()
            vStdId.Clear()
            vName.Clear()
            vTimeIn.Clear()
            vTimeOut.Clear()
            vDate.Clear()

            MessageBox.Show("Data Deleted", "DELETION")
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub

    Private Sub vView_Click(sender As Object, e As EventArgs) Handles vView.Click
        tableP.Visible = True
        Try
            connection.Open()
            command = connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT * FROM `visitor`"
            command.ExecuteNonQuery()
            DT = New DataTable()
            adapter = New MySqlDataAdapter(command)
            adapter.Fill(DT)
            DataGridView1.DataSource = DT
            connection.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR")
            connection.Close()
        End Try
    End Sub




    'TABLE INFO



    Private Sub tblExit_Click(sender As Object, e As EventArgs) Handles tblExit.Click
        tableP.Visible = False
    End Sub




    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles logOut.Click
        Me.Close()

    End Sub

    Private Sub messEmployeeP_Paint(sender As Object, e As PaintEventArgs) Handles messEmployeeP.Paint

    End Sub
End Class