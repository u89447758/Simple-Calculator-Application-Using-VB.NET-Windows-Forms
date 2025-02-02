﻿Public Class CalculatorApp


    Dim firstNumber As Double
    Dim currentOperator As String
    Dim isNewOperation As Boolean = False

    Private Sub NumberClick(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btnDecimal.Click


        Dim btn As Button = CType(sender, Button)



        If isNewOperation Then
            txtDisplay.Text = ""
            isNewOperation = False
        End If

        If btn.Text = "." Then
            If txtDisplay.Text = "" Then
                txtDisplay.Text = "0."
            ElseIf txtDisplay.Text.Contains(".") Then
                Exit Sub
            Else
                txtDisplay.Text += "."
            End If
            Exit Sub
        End If

        txtDisplay.Text += btn.Text
    End Sub

    Private Sub OperatorClick(sender As Object, e As EventArgs) Handles btnPlus.Click, btnMinus.Click, btnMultiply.Click, btnDivide.Click
        Dim btn As Button = CType(sender, Button)

        ' Validate input number
        If Not Double.TryParse(txtDisplay.Text, firstNumber) Then
            MessageBox.Show("Invalid number input")
            Exit Sub
        End If

        currentOperator = btn.Text
        isNewOperation = True
    End Sub


    Private Sub btnEquals_Click(sender As Object, e As EventArgs) Handles btnEquals.Click
        ' Check if operator was selected
        If String.IsNullOrEmpty(currentOperator) Then
            MessageBox.Show("No operator selected")
            Return
        End If

        ' Validate second number
        Dim secondNumber As Double
        If Not Double.TryParse(txtDisplay.Text, secondNumber) Then
            MessageBox.Show("Invalid number input")
            Return
        End If

        Dim result As Double

        Try
            Select Case currentOperator
                Case "+"
                    result = firstNumber + secondNumber
                Case "-"
                    result = firstNumber - secondNumber
                Case "*"
                    result = firstNumber * secondNumber
                Case "/"
                    If secondNumber = 0 Then
                        MessageBox.Show("Cannot divide by zero!")
                        Return
                    End If
                    result = firstNumber / secondNumber
            End Select

            ' Check for mathematical errors
            If Double.IsInfinity(result) OrElse Double.IsNaN(result) Then
                MessageBox.Show("Result is undefined or too large")
                txtDisplay.Text = ""
                isNewOperation = True
                Return
            End If

            txtDisplay.Text = result.ToString()
            isNewOperation = True

        Catch ex As Exception
            MessageBox.Show("Error during calculation: " & ex.Message)
            txtDisplay.Text = ""
            isNewOperation = True
        End Try
    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtDisplay.Text = ""
        firstNumber = 0
        currentOperator = ""
        isNewOperation = False
    End Sub


End Class
