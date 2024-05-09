<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab8.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Student</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        
        .p-cont {
            margin-top: 50px;
        }

        .st-form-cont {
            margin-bottom: 20px;
        }

        .table-container {
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <div class="container p-cont">
        <div class="row st-form-cont">
            <div class="col-md-6">
                <form runat="server">
                    <div class="form-group">
                        <label>Name:</label>
                        <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="nameRequiredValidator" runat="server" ControlToValidate="nameTextBox" ErrorMessage="Name is required" CssClass="error-message"/>
                    </div>
                    <div class="form-group">
                        <label>Student Type:</label>
                        <asp:DropDownList ID="studentTypeDropDown" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Select ..." Value=""></asp:ListItem>
                            <asp:ListItem Text="Full Time" Value="FullTime"></asp:ListItem>
                            <asp:ListItem Text="Part Time" Value="PartTime"></asp:ListItem>
                            <asp:ListItem Text="Coop" Value="Coop"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="studentTypeRequiredValidator" runat="server" ControlToValidate="studentTypeDropDown" ErrorMessage="Student Type is required" CssClass="error-message" />
                    </div>
                    <asp:Button ID="submitButton" runat="server" Text="Add" OnClick="SubmitButton_Click" CssClass="btn btn-primary" />
                </form>
            </div>
        </div>

        <div class="row table-container">
            <div class="col-md-12">
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Name</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="registeredStudents" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Id") %></td>
                                    <td><%# Eval("Name") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <a href="RegisterCourse.aspx">Register Course</a>
        </div>
    </div>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
