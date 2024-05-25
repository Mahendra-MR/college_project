<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="NcbJobPortal.User.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div class="container pt.50 pb-40">
            <div class="row">
                    <div class="col-12 pb-40 ">
                        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                    </div>
                    <div class="col-12 pb-20">
                        <h2 class="contact-title text-center">Sign Up</h2>
                    </div>
                    <div class="col-lg-6 mx-auto">
                        <div class="form-contact contact_form">   
                        <div class="row">
                            <div class="col-12">
                                <h6>Login Information</h6>
                            </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Username</label>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter unique Username" required></asp:TextBox>
                                       
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label>Password</label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter password" TextMode="Password" required></asp:TextBox>
                   
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                         <label>Conform Password</label>
                                <asp:TextBox ID="txtConformPassword" runat="server" CssClass="form-control" placeholder="Renter password" TextMode="Password" required></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password not matching"
                                        ControlToCompare="txtPassword" ControlToValidate="txtConformPassword" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" 
                                        Font-Size="Small"></asp:CompareValidator>
                                    </div>
                                </div>
                             <div class="col-12">
                                <h6>Personal Information</h6>
                            </div>
                                <div class="col-12">
                                    <div class="form-group">
                                         <label>Full Name</label>
                                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Enter Full Name" required></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name must be in characters only..!" 
                                    ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[a-zA-Z\s]+$"  ControlToValidate="txtFullName"></asp:RegularExpressionValidator>
                                       
                                    </div>
                                </div>
                             <div class="col-12">
                                    <div class="form-group">
                                         <label>Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Address" TextMode="MultiLine"  required></asp:TextBox>
                                       
                                    </div>
                                </div>
                             <div class="col-12">
                                    <div class="form-group">
                                         <label>Contact Number</label>
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Phone Number" required></asp:TextBox>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Mobile number must have 10 digits" 
                                    ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[0-9]{10}$"  ControlToValidate="txtMobile"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                             <div class="col-12">
                                    <div class="form-group">
                                         <label>Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email" required
                                    TextMode="Email"></asp:TextBox>
                                       
                                    </div>
                                </div>
                              <div class="col-12">
                                    <div class="form-group">
                                         <label>Select Country</label>
                                    <asp:DropDownList ID="ddlCountry" runat="server" DataSourceID="SqlDataSource1" CssClass="form-contact w-100" 
                                        AppendDataBoundItems="true" DataTextField="CountryName" DataValueField="CountryName">
                                        <asp:ListItem Value="0">Select Country</asp:ListItem>
                                         </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Country is required"
                                        ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="ddlCountry"></asp:RequiredFieldValidator>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:JobPortalConnectionString %>" SelectCommand="SELECT [CountryName] FROM [Country]"></asp:SqlDataSource>
                                    
                                </div>

                            </div>
                            <div class="form-group mt-3">
                              <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="button button-contactForm boxed-btn mr-4" 
                                  OnClick="btnRegister_Click"/>
                                <span class="clickLink"><a href="../User/Login.aspx">Already Registered Click Here...</a></span>
                           
                                </div>
                            </div>
                    </div>
                </div>
        </div>
    </section>
</asp:Content>
