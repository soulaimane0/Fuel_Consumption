<%@ Page Title="" Language="C#" MasterPageFile="~/MasPage.Master" AutoEventWireup="true" CodeBehind="MAJ_Vehicule.aspx.cs" Inherits="ALMATRANS.MAJ_Vehicule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

        var obj = { status: false, ele: null };

        function ConfirmDel(event) {

            if (obj.status) { return true; };
            swal({
                title: "Êtes-vous sûr ?",
                text: "Une fois supprimées, vous ne pourrez plus récupérer ces informations !",
                type: "warning",
                showCancelButton: true,
                cancelButtonText: "Annuler",
                confirmButtonClass: "btn btn-danger",
                confirmButtonText: "Oui, Supprimez-le",
                closeOnConfirm: true,
            },
                function () {
                    obj.status = true;
                    obj.ele = event;
                    obj.ele.click();
                }
            );
            return false;
        };


        function ConfirmUpdate(event) {

            if (obj.status) { return true; };
            swal({
                title: "Êtes-vous sûr ?",
                text: "Voulez-vous vraiment modifier cette Véhicule ?",
                type: "warning",
                showCancelButton: true,
                cancelButtonText: "Annuler",
                confirmButtonClass: "btn btn-primary",
                confirmButtonText: "Oui, Modifiez-le",
                closeOnConfirm: true,
            },
                function () {
                    obj.status = true;
                    obj.ele = event;
                    obj.ele.click();
                }
            );
            return false;
        };

    </script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row mt-4 mb-4">
            <div class="col-md-5">
                <div class="card">
                     <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/vehicles.png" width="100" height="100" />
                                </center>
                            </div>
                       </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Gestion du Parc</h3>
                                </center>
                            </div>
                       </div>
                         <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                       </div>

                         <div class="row">
                            <div class="col-md-4">
                               <label>ID Véhicule</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="txtID" CssClass="form-control" placeholder="ID" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnGO" CssClass="btn btn-secondary" runat="server" Text="GO" OnClick="btnGO_Click" />
                                </div>
                                    </div>
                            </div>
                             
                             <div class="col-md-8">
                                 <label>Immatriculation</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtImm" CssClass="form-control" placeholder="Immatriculation" MaxLength="9" runat="server" AutoPostBack="true" OnTextChanged="txtImm_TextChanged"></asp:TextBox>
                                 </div>
                             </div>
                       </div>

                         <div class="row">
                             <div class="col-6">
                                 <label>Nom Marque</label>
                                 <div class="form-group">

                                     <%-- 
                                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"  >

                                <ContentTemplate>
                                    <div class="input-group">
                                     <asp:TextBox ID="txtPrixT" CssClass="form-control" placeholder="Total" ReadOnly="true" TextMode="Number" runat="server"></asp:TextBox>
                                    <div class="input-group-append">
                                            <span class="input-group-text">DH</span>
                                          </div>
                                          </div>
                                       </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="txtPrixL" EventName="TextChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="txtQte" EventName="TextChanged" />
                                </Triggers>

                             </asp:UpdatePanel>
                                         --%>

                                     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                         <ContentTemplate>
                                              <asp:DropDownList ID="ddIdMarq" CssClass="form-control" runat="server">
                                     </asp:DropDownList>
                                         </ContentTemplate>
                                         <Triggers>
                                             <asp:AsyncPostBackTrigger ControlID="txtImm" EventName="TextChanged" />
                                         </Triggers>
                                     </asp:UpdatePanel>
                                    
                                 </div>
                             </div>

                             <div class="col-6">
                                 <label>Date en Service</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtdateServ" TextMode="Date" CssClass="form-control" placeholder="Date en service" runat="server"></asp:TextBox>
                                 
                             </div>
                         </div>
                             </div>
                         <div class="row">
                             <div class="col-4">
                                 <asp:Button ID="btnAjout" CssClass="btn btn-success btn-lg btn-block" runat="server" Text="Ajouter" OnClick="btnAjout_Click" />
                             </div>
                             <div class="col-4">
                                 <asp:Button ID="btnMod" CssClass="btn btn-primary btn-lg btn-block" runat="server" Text="Modifier" OnClick="btnMod_Click" OnClientClick="return ConfirmUpdate(this);" />
                             </div>
                             <div class="col-4">
                                 <asp:Button ID="btnSupp" CssClass="btn btn-danger btn-lg btn-block" runat="server" Text="Supprimer" OnClick="btnSupp_Click" OnClientClick="return ConfirmDel(this);" />
                             </div>
                         </div>
                 </div>    
            </div>
            </div>
            <div class="col-md-7">
                <div class="card">
                     <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>La Liste des Véhicules</h3>
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
                                 <asp:GridView ID="DGVcl" AutoGenerateColumns="false" class="table table-striped table-bordered text-center" runat="server">
                                     <Columns>
                                         <asp:BoundField DataField="id_Vcl" HeaderText="ID"  />
                                         <asp:BoundField DataField="immatriculation" HeaderText="Immatriculation"  />
                                         <asp:BoundField DataField="id_marque" HeaderText="ID Marque"  />
                                         <asp:BoundField DataField="date_service" HeaderText="Date en service" ApplyFormatInEditMode="true" SortExpression="date_service" DataFormatString="{0:d}"  />

                                     </Columns>

                                 </asp:GridView>
                             </div>
                         </div>
                         
                     </div>
                 </div>    
            </div>
       </div>
    </div>
</asp:Content>
