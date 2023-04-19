<%@ Page Title="" Language="C#" MasterPageFile="~/MasPage.Master" AutoEventWireup="true" CodeBehind="MAJ_Marque.aspx.cs" Inherits="ALMATRANS.MAJ_Marque" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>

   <script type="text/javascript">
      var obj = { status: false, ele: null };

      function ConfirmDel(event) {

          if (obj.status) { return true; };
          swal({
              title: "Êtes-vous sûr ?",
              text: "Une fois supprimées, vous ne pourrez plus récupérer ces informations !",
              type: "warning",
              showCancelButton: true,
              cancelButtonText:"Annuler",
              confirmButtonClass: "btn btn-danger",
              confirmButtonText:"Oui, Supprimez-le",
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
              text: "Voulez-vous vraiment modifier cette marque ?",
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
            <div class="col-md-6">
                <div class="card">
                     <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/truckIcon.png" width="140" height="140" />
                                </center>
                            </div>
                       </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Mise à jour du Marque</h3>
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
                               <label>ID Marque</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="txtID" CssClass="form-control" placeholder="ID" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnGO" CssClass="btn btn-secondary" runat="server" Text="GO" OnClick="btnGO_Click" />
                                </div>
                                    </div>
                            </div>
                             
                             <div class="col-md-8">
                                 <label>Nom Marque</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtNom" CssClass="form-control" placeholder="Nom Marque" runat="server"></asp:TextBox>
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

            <div class="col-md-6">
                <div class="card">
                     <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>La Liste des Marques</h3>
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
                                 <asp:GridView ID="DGVMarq" AutoGenerateColumns="false" class="table table-striped table-bordered" runat="server">
                                     <Columns>
                                         <asp:BoundField DataField="id_marque" HeaderText="ID Marque" />
                                         <asp:BoundField DataField="nom_marque" HeaderText="Nom Marque" />
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
