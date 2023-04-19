<%@ Page Title="" Language="C#" MasterPageFile="~/MasPage.Master" AutoEventWireup="true" CodeBehind="F_Statis.aspx.cs" Inherits="ALMATRANS.F_Statis" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mb-4">
            <div class="col-md-12">
                <div class="card">
                     <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Les Statistiques</h3>
                                </center>
                            </div>
                       </div>
                         <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                       </div>

                         <div class="row">
                            <div class="col-4">
                                <label>N° Immatriculation</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="DdVehicule" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdVehicule_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                </div>
                             <div class="col-4">
                                <label>Date Debut</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtDateDebut" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                                 </div>
                            </div>
                             <div class="col-4">
                                 <label>Date Fin</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtDateFin" AutoPostBack="true" TextMode="Date" CssClass="form-control" runat="server" OnTextChanged="txtDateFin_TextChanged"></asp:TextBox>
                                 </div>
                            </div>
                       </div>
                        
                          <div class="row my-3 mx-auto">
                            <div class="col-12">

                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <div style="width:1010px; overflow-x:auto;">
                                <ajaxToolkit:BarChart ID="BarChart1" runat="server" ChartHeight="500" ChartWidth="900" Height="500px" Width="1000px">
                
                                 </ajaxToolkit:BarChart>
                                </div>

                            </div>
                       </div>

                         <div class="row">
                             <div class="col-6">
                                 <asp:Label ID="lblTotal" CssClass="form-control text-success" runat="server" Text="Quantité" Font-Size="XX-Large" Font-Bold="True"></asp:Label>
                             </div>
                             <div class="col-6">
                                 <asp:Label ID="lblPrix" CssClass="form-control text-success" runat="server" Text="Total Prix" Font-Size="XX-Large" Font-Bold="True"></asp:Label>
                             </div>
                         </div>


                         </div>


                         
                     </div>
                 </div>    
        </div>
        <div class="row my-4">
            <div class="col-md-10 mx-auto">
                <div class="card">
                     <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Les informations du Véhicule</h3>
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
                                 <asp:GridView ID="DGStatis" AutoGenerateColumns="false" class="table table-striped table-bordered text-center" runat="server">
                                     <Columns>
                                         <asp:BoundField DataField="immatriculation" HeaderText="N° Immatriculatoin" />
                                         <asp:BoundField DataField="date_service" HeaderText="Date en Service" ApplyFormatInEditMode="true" SortExpression="date_service" DataFormatString="{0:d}" />
                                         <asp:BoundField DataField="Quantité" HeaderText="Quantité" />
                                         <asp:BoundField DataField="prix_total" HeaderText="Prix Total" />
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
