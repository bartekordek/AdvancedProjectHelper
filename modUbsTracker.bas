Attribute VB_Name = "modUbsTracker"
Option Explicit

Sub run()
    Dim wb As Workbook
    Dim ws As Worksheet
    Dim colDates As New Collection
    Dim rngDataRow As Range
    Dim rngData As Range
    Dim cell As Range
    Dim rngDistinct As Range
    Dim dict As New Scripting.Dictionary
    Dim temp As New Scripting.Dictionary
    Dim tempFeedback As New Scripting.Dictionary
    Dim tempDMM As New Scripting.Dictionary
    Dim feedback As String
    Dim rng As Range
    Dim rng2

    Set wb = ThisWorkbook
    Set ws = wb.Sheets("report")
    
    Application.ScreenUpdating = False
    
    Set rngDataRow = ws.Range(ws.Rows(6).Cells(1, 1), ws.Rows(6).Cells(1, 1).End(xlToRight))

    ws.AutoFilterMode = False
    rngDataRow.AutoFilter 3, "Client's feedback", xlOr, "DMM ABSTRACTS"
    
    Set cell = rngDataRow.Cells(1, 1).Offset(1, 0)

    Do While Len(cell.Text) > 0
        If Not ws.Rows(cell.Row).Hidden Then
            Set rng = ws.Range(ws.Rows(cell.Row).Cells(1, 1), ws.Rows(cell.Row).Cells(1, rngDataRow.Columns.count))
            
            If rng.Cells(1, 3) = "DMM ABSTRACTS" Then
                If rng.Cells(1, 12).Value > 0 Then
                    dict.Add rng, rng.Cells(1, 1).Text
                End If
            Else
                dict.Add rng, rng.Cells(1, 1).Text
            End If
        End If

        Set cell = cell.Offset(1, 0)
    Loop
	
	WAT();
    
    Set rngDistinct = GetDistinct(ws.Range(rngDataRow.Cells(1, 1).Offset(1, 0), cell).SpecialCells(xlCellTypeVisible))
    
    For Each rng In rngDistinct.Cells
        Set temp = DictFilter(dict, 1, rng.Text)
        Set tempFeedback = DictFilter(temp, 3, "Client's feedback")
        Set tempDMM = DictFilter(temp, 3, "DMM ABSTRACTS")
        
        If tempFeedback.count <> 1 Then
            SubmitError wb, rng.Text, tempFeedback.count
            GoTo skip
        End If
        
        feedback = tempFeedback.Keys(0).Cells(1, 9).Text
        
        For Each rng2 In tempDMM.Keys
            If Abs(DateDiff("n", rng2.Cells(1, 9), TimeValue(feedback))) < 75 Then
                rng2.Cells(1, 12) = "GREEN"
            ElseIf Abs(DateDiff("n", rng2.Cells(1, 9), TimeValue(feedback))) >= 75 And Abs(DateDiff("n", rng2.Cells(1, 9), TimeValue(feedback))) <= 120 Then
                rng2.Cells(1, 12) = "AMBER"
            Else
                rng2.Cells(1, 12) = "RED"
            End If
        Next rng2
skip:
    Next rng
    
    ws.ShowAllData
    
    Application.ScreenUpdating = True
End Sub

Function DictFilter(dict As Scripting.Dictionary, col As Integer, arg As String) As Object
    Dim dictNew As New Scripting.Dictionary
    Dim rng
    Dim i As Integer
    
    Set DictFilter = dictNew

    For Each rng In dict.Keys
        If rng.Cells(1, col).Text = arg Then
            dictNew.Add dict.Keys(i), dict.Items(i)
        End If
        
        i = i + 1
    Next rng
End Function

Function GetDistinct(rngSrc As Range) As Object
    If rngSrc.Columns.count <> 1 Then
        GetDistinct = Nothing
        Exit Function
    End If
    
    Dim rngFinal As Range
    Dim rng As Range
    
    For Each rng In rngSrc
        If Not ValueExists(rngFinal, rng.Value) Then
            If rngFinal Is Nothing Then Set rngFinal = rng
            
            If Len(rng.Text) > 0 Then Set rngFinal = Application.Union(rngFinal, rng)
        End If
    Next rng
    
    Set GetDistinct = rngFinal
End Function

Function ValueExists(rngSrc As Range, val As String) As Boolean
    Dim rng As Range
    
    If rngSrc Is Nothing Then
        ValueExists = False
        Exit Function
    End If

    For Each rng In rngSrc
        If rng.Value = val Then
            ValueExists = True
            Exit Function
        End If
    Next rng
    
    ValueExists = False
End Function

Sub SubmitError(wb As Workbook, dat As String, count As Integer)
    Dim wsErr As Worksheet
    Dim ws As Worksheet
    Dim last As Long
    Dim exists As Boolean

    For Each ws In wb.Sheets
        If ws.Name = "Errors" Then exists = True
    Next ws
    
    If Not exists Then
        Set wsErr = wb.Worksheets.Add
        wsErr.Name = "Errors"
        
        wsErr.Cells(1, 1) = "Date"
        wsErr.Cells(1, 2) = "No of feedbacks"
        wsErr.Cells(1, 3) = "Err date"
    Else
        Set wsErr = wb.Sheets("Errors")
    End If

    last = wsErr.Cells(wsErr.Cells.Rows.count, 1).End(xlUp).Row
    
    wsErr.Cells(last + 1, 1) = dat
    wsErr.Cells(last + 1, 2) = count
    wsErr.Cells(last + 1, 3) = Now
End Sub
