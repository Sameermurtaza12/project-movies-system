<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userLogin.aspx.cs" Inherits="OnlineMoviesSystem.userLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login</title>

        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" />
     <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.0/dist/jquery.slim.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.bundle.min.js"></script>
     <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.0/jquery.validate.min.js"> </script>  
    
     <!-- This is my styling classes -->
     <style type="text/css">  
    .main                      
    {  
        position:absolute;  
   
        background-color:deepskyblue;  
        }  
    .input  
    {  
        position:absolute;  
        top:100px;  
        left:150px;  
        right:150px;  
        height:50px;  
        bottom:500px;    
        }  
    .button  
    {  
        position:relative;  
        top: 10px;
        left:200px;  
        right:300px;  
        height:50px;  
        bottom:100px;    
        }
   
         </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="border:3px solid blue;  padding:5px; width:1100px; font-size:larger;">
             <!-- This is my main div  -->                
        <asp:Label for="l" Text="Welcome To Online Movies System" runat="server" Style="margin-left: 200px; margin-top:20px; font-size:xx-large; "  ></asp:Label><hr />
        <asp:Label for="l1" Text="Please Enter Your Credentials" runat="server" Style="margin-left: 200px; margin-top:20px; font-size:xx-large;" ></asp:Label><hr />
                 <!-- This div is for taking input -->
            
                <!-- This div is for taking user name -->
            <asp:Label for="labelId1" runat="server" >User Name</asp:Label> 
            <asp:TextBox ID="name" class="required" runat="server" ToolTip="enter a valid user name"></asp:TextBox><br /><br />
                 
                <!-- This div is for taking password -->
                <asp:Label for="labelId2"  runat="server" >Password</asp:Label> 
            <asp:TextBox ID="password"  class="required" TextMode="Password" runat="server" ToolTip="enter a valid password"></asp:TextBox><br /><br />
                 <div class="button">
                    <!-- This button is for only login and it will also call validateinfo function -->
       
                   <asp:Button ID="SubmitButton" class="btn btn-outline-primary btn-rounded" data-mdb-ripple-color="dark" runat="server" Text="Login" Style="margin-right: 40px "  onClick="UserLogin"/><br /> 
                     </div>
                       <div>
                        <h2>Sign Up now to register yourself</h2>
                         <div >
                    <!-- This button is for only login and it will also call validateinfo function -->
       
                   <asp:Button ID="Button2" class="btn btn-outline-primary btn-rounded" data-mdb-ripple-color="dark" runat="server" Text="Create Account" Style="margin-right: 40px " onClientClick="DisableValidation()" onClick="CreateAccount"/><br /> 
                     </div>
                    </div>
                </div>                          
        <script>   <!-- This is my function for validation it will accept the user name and password and check if it is empty or not equal to polar and vezli and throw error accordingly-->
            //function ValidateInfo() {
            //    var name = $("#name").val();   
            //    var password = $("#password").val();
                            
            //    try { 
                    
            //        if (name == "" ) throw "empty or invalid input in UserName field"
            //        if (password == "") throw "empty or invalid input in password field"
            //        return true
            //    }
            //    catch (err) {
            //        window.alert(err)
            //        return false
            //    }
            //}
            $(document).ready(function () {
                $("#form1").validate();
               
            });
            function DisableValidation() {
                $('#<%=name.ClientID%>').removeClass("required");
                 $('#<%=password.ClientID%>').removeClass("required");
                 return true;
             }
        </script>
        
    </form>
</body>
</html>
