<%@ Page Title="" Language="C#" MasterPageFile="~/MasPage.Master" AutoEventWireup="true" CodeBehind="adminConnexion.aspx.cs" Inherits="ALMATRANS.adminConnexion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container mt-3 mb-3">
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <img src="imgs/adminuser.png" width="150" height="150" />
                                    </center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h3>Connexion Administrateur</h3>
                                    </center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <label>Nom d'utilisateur</label>
                                     <div class="form-group">
                                    <asp:TextBox ID="txtnom" CssClass="form-control" placeholder="Nom d'utilisateur" runat="server"></asp:TextBox>
                                      </div>  
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Champ Obligatoire" ControlToValidate="txtnom" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                             <div class="row">
                                <div class="col">
                                    <label>Mot de passe</label>
                                    <div class="form-group">
                                    <asp:TextBox ID="txtPasse" TextMode="Password" CssClass="form-control" placeholder="Mot de passe" runat="server"></asp:TextBox>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Champ Obligatoire" ControlToValidate="txtPasse" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                    <div class="form-group">
                                    <asp:Button ID="btnConn" CssClass="btn btn-success btn-lg btn-block" runat="server" Text="Connexion" OnClick="btnConn_Click1" />
                                </div>
                                </div>
                            </div>
                        </div>

                       
                    </div>

                    <a href="AcceuilPage.aspx"> << Retour à la page d'accueil </a> <br /><br />
                </div>
            </div>
        </div>
</asp:Content>