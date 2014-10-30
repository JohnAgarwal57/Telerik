<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="RegistrationValidation.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.css" rel="stylesheet" />
</head>
<body>
    <div class="well">
        <form id="form1" runat="server" class="form-horizontal">
            <fieldset>
                <legend>Create New User</legend>

                <div class="form-group">
                    <label for="TextBoxUserName" class="col-md-2 control-label">User name</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="TextBoxUserName" runat="server" class="form-control"/>
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidatorUserName" ControlToValidate="TextBoxUserName" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Username field is required!" ForeColor="Red" EnableClientScript="true" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="TextBoxPassword" class="col-md-2 control-label">Password</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="TextBoxPassword" runat="server" class="form-control" TextMode="Password"/>
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidatorPassword" ControlToValidate="TextBoxPassword" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Password field is required!" ForeColor="Red" EnableClientScript="true" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="TextBoxRepeatPassword" class="col-md-2 control-label">Repeat Password</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="TextBoxRepeatPassword" runat="server" class="form-control" TextMode="Password"/>
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidatorPasswordRepeat" ControlToValidate="TextBoxRepeatPassword" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Password field is required!" ForeColor="Red" EnableClientScript="true" />
                    </div>
                </div>

                <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                    ControlToCompare="TextBoxPassword"
                    ControlToValidate="TextBoxRepeatPassword" Display="Dynamic"
                    ErrorMessage="Password doesn't match!" ForeColor="Red" EnableClientScript="true">
                </asp:CompareValidator>

                <div class="form-group">
                    <label for="TextBoxFirstName" class="col-md-2 control-label">First name</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="TextBoxFirstName" runat="server" class="form-control"/>
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidatorFirstName" ControlToValidate="TextBoxFirstName" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="First name field is required!" ForeColor="Red" EnableClientScript="true" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="TextBoxLastName" class="col-md-2 control-label">Last name</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="TextBoxLastName" runat="server" class="form-control"/>
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidatorLastName" ControlToValidate="TextBoxLastName" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Last name field is required!" ForeColor="Red" EnableClientScript="true" />
                    </div>
                </div>

                 <div class="form-group">
                    <label for="TextBoxAge" class="col-md-2 control-label">Age</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="TextBoxAge" runat="server" class="form-control" TextMode="Number"/>
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidatorAge" ControlToValidate="TextBoxAge" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Age field is required!" ForeColor="Red" EnableClientScript="true" />
                        <asp:RangeValidator ID="RangeValidatorAge" ControlToValidate="TextBoxAge" runat="server" Display="Dynamic" Text="Required Field"  ErrorMessage="Age must be between 18 and 81" ForeColor="Red" MinimumValue="18" MaximumValue="81" Type="Integer" EnableClientScript="true" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="TextBoxEmail" class="col-md-2 control-label">Email</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="TextBoxEmail" runat="server" class="form-control" TextMode="Email"/>
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidatorEmail" ControlToValidate="TextBoxEmail" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Email field is required!" ForeColor="Red" EnableClientScript="true" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" ControlToValidate="TextBoxEmail" runat="server" Display="Dynamic" Text="Not valid email" ForeColor="Red" EnableClientScript="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="TextBoxAddress" class="col-md-2 control-label">Address</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="TextBoxAddress" runat="server" class="form-control"/>
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidatorAddress" ControlToValidate="TextBoxAddress" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Address field is required!" ForeColor="Red" EnableClientScript="true" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="TextBoxPhone" class="col-md-2 control-label">Phone</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="TextBoxPhone" runat="server" class="form-control" TextMode="Phone"/>
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidatorPhone" ControlToValidate="TextBoxPhone" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Phone field is required!" ForeColor="Red" EnableClientScript="true" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorhone" ControlToValidate="TextBoxPhone" runat="server" Display="Dynamic" Text="Not valid phone" ForeColor="Red" EnableClientScript="true" ValidationExpression="\d{2}/\d{7}" />
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-2 control-label"></label>
                    <div class="col-md-10">
                        <asp:CheckBox ID="CheckBoxAccept" runat="server" Text="I agree"/>
                        <asp:CustomValidator runat="server" ID="CheckBoxRequired" EnableClientScript="true" OnServerValidate="CheckBoxRequired_ServerValidate" ForeColor="Red" Text="You must select this box to proceed."/>
                    </div>
                </div>

                <div class="pull-right">
                    <asp:Button ID="ButtonSubmit" runat="server" Text="Register" class="btn btn-primary" OnClick="ButtonSubmit_Click"/>
                </div>
            </fieldset>

            <asp:ValidationSummary runat="server" ForeColor="Red" />
        </form>
    </div>

</body>
</html>
