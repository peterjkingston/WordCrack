Attribute VB_Name = "WordCrack"
Option Explicit

Public Sub Button_Click()
    Dim letter As String, letters As String, textBox As Range, i As Integer, letterCollection As Collection, wordCollection As Collection, j As Integer
    Set textBox = ThisWorkbook.Sheets("Sheet1").Cells(1, 1)
    Set letterCollection = New Collection
    
    letters = textBox.Text
    For i = 1 To Len(letters)
        letter = Mid(letters, i, 1)
        letterCollection.Add letter
    Next i
    
    Set wordCollection = Unscramble(letterCollection, 3)
    
    i = 3
    For j = 1 To wordCollection.count
         ThisWorkbook.Sheets("Sheet1").Cells(i, 1).Value = wordCollection(j)
         i = i + 1
    Next j

End Sub

Private Function Unscramble(letters As Collection, minWDLen As Integer) As Collection
    Dim result As Collection, wordDict As Dictionary, wdLen As Integer, combo As String, attempt As Integer, comboDict As Dictionary
    Set result = New Collection
    
    For wdLen = minWDLen To letters.count
        Set comboDict = GetComboDict(letters, wdLen)
        For attempt = 0 To comboDict.count - 1
            combo = comboDict.items(attempt)
            If Excel.Application.CheckSpelling(combo) Then
                result.Add combo
            End If
        Next attempt
    Next wdLen
    
    Set Unscramble = result
End Function
Private Function GetDictionary() As Dictionary
    ''Most time eaten up here
    Dim result As Dictionary, fso As FileSystemObject, tStream As TextStream, word As String
    Set result = New Dictionary
    Set fso = New FileSystemObject
    Set tStream = fso.OpenTextFile("") ''Insert text dictionary
    
    Do Until tStream.AtEndOfStream
        word = LCase(tStream.ReadLine)
        If Not result.Exists(word) Then: result.Add word, word
    Loop
    
    Set GetDictionary = result
End Function
Private Function GetComboDict(items As Collection, _
                              comboLength As Integer, _
                              Optional repeatItemAllowed As Boolean = False) As Dictionary
    Dim i As Integer, temp As Collection, comboItem As String, pool As Collection, comboDict As Dictionary, combo As String, blank As Collection, bool As Boolean
    Set comboDict = New Dictionary
    Set temp = New Collection
    Set blank = New Collection
    Set pool = CloneCollection(items)
    bool = GetCombo(blank, pool, 0, comboLength, temp)
    
    For i = 1 To temp.count
        comboItem = temp(i)
        If Not comboDict.Exists(comboItem) Then
            comboDict.Add comboItem, comboItem
        End If
    Next i
    
    Set GetComboDict = comboDict
End Function
Private Function CloneCollection(thisCollection As Collection) As Collection
    Dim newCollection As Collection, i As Integer
    Set newCollection = New Collection
    
    For i = 1 To thisCollection.count
        newCollection.Add thisCollection(i)
    Next i
    
    Set CloneCollection = newCollection
End Function
Private Function GetString(letters As Collection) As String
    Dim newString As String, i As Integer
    For i = 1 To letters.count
        newString = newString & letters(i)
    Next i
    GetString = newString
End Function
Private Function GetCombo(currentClone As Collection, poolClone As Collection, recursion As Integer, maxRecursion As Integer, out As Collection) As Boolean
    Dim i As Integer, bool As Boolean, newCollection As Collection, newPool As Collection
    If Not IsObject(out) Then: Set out = New Collection
    On Error GoTo ErrorHandler
    If recursion = maxRecursion Or currentClone.count = maxRecursion Then
        out.Add GetString(currentClone)
        GetCombo = True
        Exit Function
    End If
    
    
    For i = 1 To poolClone.count
        Set newCollection = CloneCollection(currentClone)
        Set newPool = CloneCollection(poolClone)
        newCollection.Add poolClone(i)
        newPool.Remove i
        bool = GetCombo(newCollection, newPool, recursion + 1, maxRecursion, out)
    Next i
    GetCombo = True
Exit Function
ErrorHandler:
    Stop
    Resume
End Function


