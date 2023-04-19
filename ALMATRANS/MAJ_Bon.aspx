<%@ Page Title="" Language="C#" MasterPageFile="~/MasPage.Master" AutoEventWireup="true" CodeBehind="MAJ_Bon.aspx.cs" Inherits="ALMATRANS.MAJ_Bon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />


        <script type="text/javascript">
            $(document).ready(function () {
                $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }



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
                 text: "Voulez-vous vraiment modifier cette Bon",
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

     <div class="container-fluid">
        <div class="row mt-4 mb-4">
            <div class="col-md-5">
                <div class="card">
                     <div class="card-body">
                           <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Détails du Bon </h4>
                                </center>
                            </div>
                       </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview" src="Vehicules/no-pictures.png"  width="150" height="150" />
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
                                <asp:FileUpload onchange="readURL(this);" ID="FileUpload1" CssClass="form-control" runat="server" />
                            </div>
                       </div>

                         <div class="row mt-2">
                            <div class="col-md-5">
                               <label>Numéro Bon *</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="txtNum" CssClass="form-control" placeholder="Numéro" runat="server"></asp:TextBox>

                                    <asp:LinkButton ID="btnAff" CssClass="btn btn-secondary" runat="server" OnClick="btnAff_Click1">GO</asp:LinkButton>
                                </div>
                                    </div>
                            </div>
                             
                             <div class="col-md-7">
                                 <label>Date de Bon *</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtdate" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                                 </div>
                             </div>
                       </div>

                         <div class="row">
                             <div class="col-4">
                                 <label>Nom du Station</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtNomStas" CssClass="form-control" placeholder="Nom du Station" runat="server"></asp:TextBox>
                                 </div>
                             </div>

                             <div class="col-4">
                                 <label>Immatriculation *</label>
                                 <div class="form-group">
                                      <asp:DropDownList ID="ddIdVcl" CssClass="form-control" runat="server"></asp:DropDownList>
                                 
                             </div>
                         </div>

                             <script type="text/javascript">
                                 $('#<%=ddIdVcl.ClientID%>').chosen();
                             </script>


                              <div class="col-4">
                                 <label>Nom du Chauffeur</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtChauf" CssClass="form-control" placeholder="Nom du Chauffeur" runat="server"></asp:TextBox>
                                 
                             </div>
                         </div>
                             </div>

                         
                          


                         <div class="row">
                             <div class="col-4">
                                 <label>Quantité *</label>
                                 <div class="form-group">
                                       <div class="input-group">

                                     <asp:TextBox ID="txtQte" CssClass="form-control" placeholder="Quentité" TextMode="Number" runat="server" AutoPostBack="true" OnTextChanged="txtQte_TextChanged"></asp:TextBox>
                                            <div class="input-group-append">
                                            <span class="input-group-text">L</span>
                                          </div>

                                           </div>
                                 </div>
                             </div>

                             <div class="col-4">
                                 <label>Prix du litre *</label>
                                 <div class="form-group">
                                    <div class="input-group">

                                <asp:TextBox ID="txtPrixL" CssClass="form-control" placeholder="Prix L" TextMode="Number" step="any" runat="server" OnTextChanged="txtPrixL_TextChanged" AutoPostBack="true"></asp:TextBox>      
                                         <div class="input-group-append">
                                            <span class="input-group-text">DH</span>
                                          </div>
                                    </div>        

                             </div>
                         </div>

                              <div class="col-4">
                                 <label>Prix Total</label>
                                 <div class="form-group">
                                     
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
                                  
                              
                             </div>
                         </div>
                             </div>


                         <div class="row">
                             <div class="col-4">
                                 <asp:Button ID="btnAjout" CssClass="btn btn-success btn-lg btn-block" runat="server" Text="Ajouter" OnClick="btnAjout_Click" />
                             </div>
                             <div class="col-4">
                                 <asp:Button ID="btnMod" OnClientClick="return ConfirmUpdate(this);" CssClass="btn btn-primary btn-lg btn-block" runat="server" Text="Modifier" OnClick="btnMod_Click" />
                             </div>
                             <div class="col-4">
                                 <asp:Button ID="btnSupp" OnClientClick="return ConfirmDel(this);" CssClass="btn btn-danger btn-lg btn-block" runat="server" Text="Supprimer" OnClick="btnSupp_Click" />
                             </div>
                         </div>

                         <div class="row mt-4">
                             <div class="col-10 mx-auto">
                                 <asp:Button ID="btnImpr" CssClass="btn btn-outline-secondary btn-lg btn-block" runat="server" Text="Imprimer le bon" OnClick="btnImpr_Click" />
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
                                    <h3>La Liste des Bons</h3>
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
                                 <asp:GridView ID="DGBon" AutoGenerateColumns="False" class="table table-striped table-bordered" runat="server" DataKeyNames="Num_Bon" DataSourceID="SqlDataSource1">

                                     <Columns>
                                         <asp:BoundField DataField="Num_Bon" HeaderText="Numéro" ReadOnly="true" SortExpression="Num_Bon" />

                                         <asp:TemplateField>
                                             <ItemTemplate>
                                                 <div class="container-fluid">
                                                     <div class="row">
                                                         <div class="col-lg-9">
                                                            <div class="row">
                                                                <div class="col">

                                                                    Date du Bon -
                                                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text='<%# Eval("date_Bon", "{0:d}") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                             <div class="row">
                                                                <div class="col">

                                                                    Nom du Station -
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("nom_station") %>'></asp:Label>
                                                                    &nbsp; |&nbsp; ID Véhicule -
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("id_Vcl") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                             <div class="row">
                                                                <div class="col">

                                                                    Nom du Chauffeur -
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("nom_Chauf") %>'></asp:Label>
                                                                    &nbsp; |&nbsp; Quantité -
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("Qté") %>'></asp:Label>
                                                                    L</div>
                                                            </div>
                                                             <div class="row">
                                                                <div class="col">

                                                                    Prix du Litre -
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("prix_littre") %>'></asp:Label>
                                                                    Dh&nbsp; |&nbsp; Prix Total -
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("prix_total") %>'></asp:Label>
                                                                    Dh</div>
                                                            </div>
                                                         </div>


                                                         <div class="col-lg-3">
                                                             <asp:Image class="img-fluid p-2" ID="Image1" style="width:200px; height:120px"  runat="server" ImageUrl='<%# Eval("photo") %>' />
                                                         </div>
                                                     </div>
                                                 </div>
                                             </ItemTemplate>
                                         </asp:TemplateField>

                                     </Columns>
                                 </asp:GridView>
                                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Db_ALMATRANSConnectionString %>" SelectCommand="SELECT * FROM [Bon]"></asp:SqlDataSource>
                             </div>
                         </div>
                         
                     </div>
                 </div>    
            </div>
       </div>
    </div>

</asp:Content>
