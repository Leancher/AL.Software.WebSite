Partial Class Page_Statistics
    Inherits UserControl
    Private Sub Page_Statistics_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Database As New DatabaseConnect()
        Dim CountCategory As Integer
        Dim CountItemCategory As Integer
        Dim CountView As String
        Database.DatabaseOpen()
        CountCategory = Database.GetCountItem(Config.CategoryTable)
        For NumberCategory = 1 To CountCategory
            Dim CategoryName = Database.GetItemByID(Config.CategoryTable, NumberCategory, "Name")
            CountItemCategory = Database.GetCountItem(CategoryName)
            Dim NumberItem As Integer
            For NumberItem = 1 To CountItemCategory
                CountView = Database.GetItemByID(CategoryName, NumberItem, "Viewed")
                If CountView <> "0" Then
                    Dim Str1 As New Label()
                    Str1.Text = Database.GetItemByID(CategoryName, NumberItem, "Caption") + " - " + CountView + "</br>"
                    StatBlcok.Controls.Add(Str1)
                End If
            Next NumberItem
        Next NumberCategory
        Database.DatabaseClose()
    End Sub
End Class
