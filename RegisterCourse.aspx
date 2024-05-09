<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Course</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .p-cont {
            margin-top: 50px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .error-message {
            color: red;
        }

        .add-student-link {
            display: block;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container p-cont">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label for="studentDropDown">Select Student:</label>
                        <asp:DropDownList ID="studentDropDown" runat="server" CssClass="form-control" AppendDataBoundItems="true"  DataTextField="FullName" DataValueField="Id" AutoPostBack="true" OnSelectedIndexChanged="studentDropDown_SelectedIndexChanged">
                            <asp:ListItem Text="-- Select Student --" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="studentRequiredValidator" runat="server" ControlToValidate="studentDropDown" ErrorMessage="Please select a student" CssClass="error-message" />
                    </div>
                    <div class="form-group">
                        <h4>Registration Summary:</h4>
                        <p>
                            <asp:Label ID="registrationSummaryLabel" runat="server"></asp:Label>
                        </p>
                    </div>
                    <div class="form-group">
                        <h4>Select Courses:</h4>
                        <asp:CheckBoxList ID="coursesCheckBoxList" runat="server" CssClass="form-check">
                        </asp:CheckBoxList>
                    </div>
                    <asp:Button ID="submitButton" runat="server" Text="Save Registration" OnClick="submitButton_Click" CssClass="btn btn-primary" />
                    <asp:Label ID="errorLabel" runat="server" CssClass="error-message" Visible="false"></asp:Label>
                </div>
            </div>
            <a href="AddStudent.aspx" class="add-student-link">Click to Add More Students</a>
        </div>
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
