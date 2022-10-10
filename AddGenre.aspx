<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddGenre.aspx.cs" Inherits="OnlineMoviesSystem.AddGenre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Genre</title>
           <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.6.1.js" integrity="sha256-3zlB5s2uwoUzrXK3BT7AX3FyvojsraNFxCc2vC/7pNI=" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.3/dist/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/css/jquery.dataTables.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.12.1/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <style type="text/css">  
   
    .input  
    {  
        position:relative;  
        top:100px;  
        left:150px;  
        right:150px;  
        height:50px;  
        bottom:500px;    
        }  
    
        </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">
                   
            <asp:Button ID="Button1" class="btn btn-outline-primary btn-rounded" data-mdb-ripple-color="dark" Style="margin-right: 40px" runat="server" Text="Logout" OnClick="Logout" />
            <asp:Button ID="Button2" class="btn btn-outline-primary btn-rounded" data-mdb-ripple-color="dark" Style="margin-right: 40px" runat="server" Text="GoBack" OnClick="BackLoad" />
     
            <br /><br />
             </div>
       
            
               <!-- This is my main div  -->
            <div class="container" style="border:3px solid blue;  padding:5px; width:1100px; font-size:larger;">
                
        <asp:Label for="l" Text="Hello Admin Welcome To Genre Form" runat="server" Style="margin-left: 200px; margin-top:20px; font-size:xx-large; "  ></asp:Label><hr />  
                 <!-- This div is for taking input -->
      
                <!-- This div is for taking user name -->
            <asp:Label for="labelId1" runat="server" >Genre Name</asp:Label> 
            <asp:TextBox ID="name" runat="server" ToolTip="enter a valid user name"></asp:TextBox><br /><br />
                 
                    <div class="container">
                    <!-- This button is for only login and it will also call validateinfo function -->
       
                   <asp:Button ID="SubmitButton" class="btn btn-outline-primary btn-rounded" data-mdb-ripple-color="dark" runat="server" Text="Add" Style="margin-right: 40px " OnClientClick="javascript : return ValidateInfo()"  onClick="AddGenreNow"/><br /> 
                     </div>
                </div>
                                 
       
       <script>   <!-- This is my function for validation it will accept the user name and password and check if it is empty or not equal to polar and vezli and throw error accordingly-->
            function ValidateInfo() {
                var name = $("#name").val();               
               
                try {
                    if (name == "" ) throw "empty or invalid input in movie name field"            
                    return true
                }
                catch (err) {
                    window.alert(err)
                    return false
                }
            }
        </script>
    </form>
</body>
</html>
