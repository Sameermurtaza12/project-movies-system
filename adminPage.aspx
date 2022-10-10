<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="OnlineMoviesSystem.adminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Page</title>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.6.1.js" integrity="sha256-3zlB5s2uwoUzrXK3BT7AX3FyvojsraNFxCc2vC/7pNI=" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.3/dist/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/css/jquery.dataTables.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.12.1/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                url: 'adminPage.aspx/ShowMovies',
                method: 'post',
                dataType: 'json',
                contentType: 'application/json',
                async: false,
                success: function (data) {
                    $('#datatable').dataTable({
                        data: JSON.parse(data.d),
                        columns: [
                            { 'data': 'movieId' },
                            { 'data': 'movieName' },
                            {
                                'data': 'moviePrice',
                                'render': function (moviePrice) {
                                    return "$" + moviePrice;
                                }
                            },
                            { 'data': 'movieRating' },
                            { 'data': 'genreName' },
                            {
                                'data': 'movieId',
                                'render': function (data) {
                                    return '<button type="button" class="btn btn-primary " id="delete" onclick="DeleteHere(' + data + ');return false;"><strong>Delete Movie</strong>'
                                },
                            },

                        ]
                    });
                }
            });
        });
        function DeleteHere(data) {
            $.ajax({
                url: 'adminPage.aspx/DeleteMovie',
                method: 'post',
                dataType: 'json',
                data: JSON.stringify({ "data": data }),
                contentType: 'application/json',
                async: false,
                success: function (data) {
                    window.location = "adminPage.aspx";
                }
            });
        };        

    </script>
    <style type="text/css">
        .button {
            position: relative;
            top: 10px;
            left: 200px;
            right: 300px;
            height: 50px;
            bottom: 100px;
        }
    </style>
</head>
<body style="font-family: Arial">

    <h1 id="head" runat="server"></h1>
    <hr />
    <h2>This is your home page</h2>

    <form id="form1" runat="server" method="post">
        <div class="container">
            <!-- This button is for logout the user and it will take you to the login page -->
            <asp:Button ID="SubmitButton" class="btn btn-outline-primary btn-rounded" runat="server" Text="Logout" OnClick="Logout" /><br /><br />
        </div>
        <div class="container" style="border: 3px solid blue; padding: 5px; width: 1100px; font-size: larger;">
            <table id="datatable">
                <thead>
                    <tr>
                        <th>Movie Id</th>
                        <th>Movie Name</th>
                        <th>Movie Price</th>
                        <th>Movie Rating</th>
                        <th>Genre</th>
                        <th>Delete</th>
                    </tr>
                </thead>
            </table>
        </div>
        <hr />
        <div>
            <h1>Add new Movies Here </h1>
        </div>
        <div class="container">
            <div>
                <!-- This button is for only login and it will also call validateinfo function -->
                <asp:Button ID="Button2" class="btn btn-outline-primary btn-rounded" data-mdb-ripple-color="dark" runat="server" Text="Add Now" Style="margin-right: 40px" OnClick="AddMovies" /><br />
            </div>

        </div>
        <hr />
        <div>
            <h1>Add new Genre Here</h1>
        </div>
        <div class="container">
            <div>
                <!-- This button is for only login and it will also call validateinfo function -->
                <asp:Button ID="Button1" class="btn btn-outline-primary btn-rounded" data-mdb-ripple-color="dark" runat="server" Text="Add Now" Style="margin-right: 40px" OnClick="AddGenre" /><br />
            </div>

        </div>
        <hr />
    </form>
</body>
</html>
