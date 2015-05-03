Imports System.Reflection

Public Class frmAbout
    Private vAssem As Assembly
    'Use this link as a reference for assemblies (http://msdn.microsoft.com/en-us/library/1h52t681.aspx)

    Private Function GetAssemblyTitle() As String
        'Found this code here (http://www.vb-helper.com/howto_net_get_program_version.html)

        ' Return the assembly's Title attribute value.
        If vAssem.IsDefined(GetType(AssemblyTitleAttribute), True) Then
            Dim attr As Attribute = Attribute.GetCustomAttribute(vAssem, GetType(AssemblyTitleAttribute))
            Dim title_attr As AssemblyTitleAttribute = DirectCast(attr, AssemblyTitleAttribute)
            Return title_attr.Title
        Else
            Return ""
        End If
    End Function

    Private Function GetAssemblyCompany() As String
        ' Return the assembly's Company attribute value.
        If vAssem.IsDefined(GetType(AssemblyCompanyAttribute), True) Then

            Dim vAttr As Attribute = Attribute.GetCustomAttribute(vAssem, GetType(AssemblyCompanyAttribute))
            Dim vCompAttr As AssemblyCompanyAttribute = DirectCast(vAttr, AssemblyCompanyAttribute)
            Return vCompAttr.Company

        Else
            Return ""
        End If
    End Function

    Private Function GetAssemblyProduct() As String

        'Return the assembly's product attribute value
        If vAssem.IsDefined(GetType(AssemblyProductAttribute), True) Then
            Dim vAttr As Attribute = Attribute.GetCustomAttribute(vAssem, GetType(AssemblyProductAttribute))
            Dim vProdAttr As AssemblyProductAttribute = DirectCast(vAttr, AssemblyProductAttribute)
            Return vProdAttr.Product

        Else
            Return ""

        End If
    End Function

    Private Function GetAssemblyCopyright() As String
        'Return the assembly's Copyright attribute value
        If vAssem.IsDefined(GetType(AssemblyCopyrightAttribute), True) Then
            Dim vAttr As Attribute = Attribute.GetCustomAttribute(vAssem, GetType(AssemblyCopyrightAttribute))
            Dim vCopyAttr As AssemblyCopyrightAttribute = DirectCast(vAttr, AssemblyCopyrightAttribute)
            Return vCopyAttr.Copyright

        Else
            Return ""

        End If
    End Function

    Private Function GetAssemblyTrademark() As String
        'Return the assembly's Trademark attribute value
        If vAssem.IsDefined(GetType(AssemblyTrademarkAttribute), True) Then
            Dim vAttr As Attribute = Attribute.GetCustomAttribute(vAssem, GetType(AssemblyTrademarkAttribute))
            Dim vTradeAttr As AssemblyTrademarkAttribute = DirectCast(vAttr, AssemblyTrademarkAttribute)
            Return vTradeAttr.Trademark

        Else

            Return ""

        End If
    End Function

    Private Function GetAssemblyFileVersion() As String
        'Return the assembly's File Version attribute value
        If vAssem.IsDefined(GetType(AssemblyFileVersionAttribute), True) Then
            Dim vAttr As Attribute = Attribute.GetCustomAttribute(vAssem, GetType(AssemblyFileVersionAttribute))
            Dim vFileVersion As AssemblyFileVersionAttribute = DirectCast(vAttr, AssemblyFileVersionAttribute)
            Return vFileVersion.Version

        Else

            Return ""

        End If
    End Function

    Private Function GetAssemblyDescription() As String
        'Return the assembly's Description attribute value
        If vAssem.IsDefined(GetType(AssemblyDescriptionAttribute), True) Then
            Dim vAttr As Attribute = Attribute.GetCustomAttribute(vAssem, GetType(AssemblyDescriptionAttribute))
            Dim vDescAttr As AssemblyDescriptionAttribute = DirectCast(vAttr, AssemblyDescriptionAttribute)
            Return vDescAttr.Description

        Else

            Return ""

        End If
    End Function

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load labels with About information

        vAssem = Assembly.GetExecutingAssembly()

        'Title
        lblTitle.Text = GetAssemblyTitle()

        'Company
        txtComp.Text = GetAssemblyCompany()

        'Product
        txtProd.Text = GetAssemblyProduct()

        'Copyright
        lblCopy.Text = GetAssemblyCopyright()

        'Trademark
        lblTrade.Text = GetAssemblyTrademark()

        'File Version
        txtFile.Text = GetAssemblyFileVersion()

        'Description
        txtDesc.Text = GetAssemblyDescription()

    End Sub

End Class