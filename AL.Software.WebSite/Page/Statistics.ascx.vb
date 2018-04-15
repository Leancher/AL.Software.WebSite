Partial Class Page_Statistics
    Inherits UserControl
    Private Sub Page_Statistics_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Database As New DatabaseConnect()
        Dim CountCategory As Integer
        Dim CountItemCategory As Integer
        Dim CountView As String
        Dim StatStr As String = ""
        Dim Caption As String = ""
        Database.DatabaseOpen()
        CountCategory = Database.GetCountItem(Config.CategoryTable)
        For NumberCategory = 1 To CountCategory
            Dim CategoryName = Database.GetItemByID(Config.CategoryTable, NumberCategory, "Name")
            CountItemCategory = Database.GetCountItem(CategoryName)
            Dim NumberItem As Integer
            For NumberItem = 1 To CountItemCategory
                CountView = Database.GetItemByID(CategoryName, NumberItem, "Viewed")
                If CountView <> "0" Then
                    Caption = Database.GetItemByID(CategoryName, NumberItem, "Caption")
                    Dim Str1 As New Label()
                    Str1.Text = Caption + " - " + CountView + "</br>"
                    StatBlcok.Controls.Add(Str1)
                End If
            Next NumberItem
        Next NumberCategory
        If StatStr = "" Then Response.Write("Нет просмотров")
        Database.DatabaseClose()
    End Sub
End Class
