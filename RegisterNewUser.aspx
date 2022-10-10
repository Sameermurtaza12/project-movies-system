<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterNewUser.aspx.cs" Inherits="OnlineMoviesSystem.RegisterNewUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registeration page</title>
       <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" />
     <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.0/dist/jquery.slim.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.bundle.min.js"></script>
     <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.0/jquery.validate.min.js"> </script>  
     <!-- This is my styling classes -->
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
        <div class="container" style="border:3px solid blue;  padding:5px; width:1100px; font-size:larger;">
             <!-- This is my main div  -->
                <asp:Label for="l" Text="Welcome To Customer Registeration form" runat="server" Style="margin-left: 200px; margin-top:20px; font-size:xx-large; "  ></asp:Label><hr />  
                <asp:Label for="l1" Text="Please Enter your information carefully" runat="server" Style="margin-left: 200px; margin-top:20px; font-size:xx-large; "  ></asp:Label><hr />  
                <!-- This div is for taking user name -->
            <asp:Label for="labelId1" runat="server" >User Name</asp:Label> 
            <asp:TextBox ID="name" runat="server" Class="required"  ToolTip="enter a valid user name"></asp:TextBox><br /><br />
                 
                <!-- This div is for taking password -->
                <asp:Label for="labelId2" runat="server" >Password</asp:Label> 
            <asp:TextBox ID="password" runat="server" Class="required password"   ToolTip="enter a valid password"></asp:TextBox><br /><br />

                  <!-- This div is for taking Full name -->
                <asp:Label for="labelId3" runat="server" >Full Name</asp:Label> 
            <asp:TextBox ID="fullName" Class="required" runat="server" ToolTip="enter a valid name"></asp:TextBox><br /><br />

                  <!-- This div is for taking contact number -->
                <asp:Label for="labelId4" runat="server" >Contact number</asp:Label> 
            <asp:TextBox ID="contact" type="number" Class="required" runat="server" ToolTip="enter a valid number"></asp:TextBox><br /><br />

                  <!-- This div is for taking address -->
                <asp:Label for="labelId5" runat="server" >Address</asp:Label> 
            <asp:TextBox ID="address" Class="required" runat="server" ToolTip="enter a valid address"></asp:TextBox><br /><br />

                  <!-- This div is for taking city -->
                <asp:Label for="labelId6" runat="server" >City Name</asp:Label> 
            <asp:TextBox ID="city" Class="required" runat="server" ToolTip="enter a valid city name"></asp:TextBox><br /><br />

                    <!-- This div is for taking country name -->
                <asp:Label for="labelId7" runat="server" >Country Name</asp:Label> 
            <asp:TextBox ID="country" Class="required" runat="server" ToolTip="enter a valid country name"></asp:TextBox><br /><br />

                    <!-- This div is for taking state name -->
                <asp:Label for="labelId8" runat="server" >State Name</asp:Label> 
            <asp:TextBox ID="state" type="text" Class="required" runat="server" ToolTip="enter a valid state name"></asp:TextBox><br /><br />

                    <!-- This div is for taking age -->
                <asp:Label for="labelId9" runat="server" >Age</asp:Label> 
            <asp:TextBox ID="age" Type="number" Class="required" runat="server" ToolTip="enter your age"></asp:TextBox><br /><br />

                 <div class="container">
                    <!-- This button is for only login and it will also call validateinfo function -->
       
                   <asp:Button ID="SubmitButton" class="btn btn-outline-primary btn-rounded" data-mdb-ripple-color="dark" runat="server" Text="Login" Style="margin-right: 40px " OnClientClick="javascript : return ValidateInfo()" onClick="RegisterCustomer"/><br /> 
                     </div>
                </div>
        <script>   <!-- This is my function for validation it will accept the user name and password and check if it is empty or not equal to polar and vezli and throw error accordingly-->
            function ValidateInfo() {
                var name = $("#name").val();   
                var password = $("#password").val();
                var fullName = $("#fullName").val();
                var contact = $("#contact").val();
                var address = $("#address").val();
                var city = $("#city").val();
                var country = $("#country").val();
                var state = $("#state").val();
                var age = $("#age").val();
                try {
                    if (name == "" ) throw "empty or invalid input in UserName field"
                    if (password == "") throw "empty or invalid input in password field"
                    if (fullName == "") throw "empty or invalid input in fullName field"
                    if (contact == "") throw "empty or invalid input in contact field"
                    if (address == "") throw "empty or invalid input in address field"
                    if (city == "") throw "empty or invalid input in city field"
                    if (country == "") throw "empty or invalid input in country field"
                    if (state == "") throw "empty or invalid input in state field"
                    if (age == "" || age<=0) throw "empty or invalid input in age field"
                    return true
                }
                catch (err) {
                    window.alert(err)
                    return false
                }
            }
            $(document).ready(function () {
                var age = $("#age").val();
                $("#form1").validate();
                rules: {
                    age: {
                        number: true
                        min : 5
                    }
                    contact : {
                        number:true
                    }
                    state: {
                        lettersonly: true
                    }
                }
              

            });
            $('#fullName').keyup(function (event) {
                
                var inputVal = $(this).val();
                var regex = new RegExp("[0-9]");
                if (regex.test(inputVal)) {
                    event.preventDefault();
                }
            });
        </script>
        
    </form>
</body>
</html>
