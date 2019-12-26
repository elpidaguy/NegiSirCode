<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="banner col-md-8">
			<section class="slider">
				<div class="flexslider" id="SliderDiv" runat="server">
					
				</div>
					</section>
				 <!-- FlexSlider -->
				 <script defer src="js/jquery.flexslider.js"></script>
				 <link rel="stylesheet" href="css/flexslider.css" type="text/css" media="screen" />
					<script type="text/javascript">
					    $(function () {
					        SyntaxHighlighter.all();
					    });
					    $(window).load(function () {
					        $('.flexslider').flexslider({
					            animation: "slide",
					            start: function (slider) {
					                $('body').removeClass('loading');
					            }
					        });
					    });
			 </script>
         </div>
    <div class="col-md-4 banner-right">
			<h4>Instant Ticket Booking</h4>
			<div class="grid_3 grid_5">
				   <div class="bs-example bs-example-tabs" role="tabpanel" data-example-id="togglable-tabs">
			<ul id="myTab" class="nav nav-tabs" role="tablist">
			  <li role="presentation" class="active"><a href="#home" id="home-tab" role="tab" data-toggle="tab" aria-controls="home" aria-expanded="true">Movies</a></li>
			</ul>
			<div id="myTabContent" class="tab-content">
			  <div role="tabpanel" class="tab-pane fade in active" id="home" aria-labelledby="home-tab">				  
                    <div class="fleft">
                                              
                    
					<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                           <ContentTemplate>
                               <asp:DropDownList ID="SelectMovie" runat="server" CssClass="list_of_movies" OnSelectedIndexChanged="SelectMovie_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                               <asp:DropDownList ID="SelectTheatre" runat="server" CssClass="list_of_movies"></asp:DropDownList>
                               <asp:DropDownList ID="SelectDate" runat="server" CssClass="list_of_movies"></asp:DropDownList>
                                <asp:DropDownList ID="SelectSeats" runat="server" CssClass="list_of_movies"></asp:DropDownList>
                                <asp:DropDownList ID="SelectShowTime" runat="server" CssClass="list_of_movies"></asp:DropDownList>
                           </ContentTemplate>
                       </asp:UpdatePanel>
                        </div>
                   
                    
			  </div>
			    <asp:Button ID="book_ticket" runat="server" Text="Book Ticket" CssClass="btn btn-primary btn-sm" OnClick="book_ticket_Click"/>
               
			</div>
		   </div>
		  </div>
		 </div>
		 <div class="clearfix"></div>
    <div class="review-slider">
        <ul id="flexiselDemo1">
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1">
                <ItemTemplate>
                       <li>
                        <a href="MovieInfo.aspx?MovieID=<%# Eval("MovieID").ToString() %>">
                            <img src="<%# Eval("MovieImage").ToString() %>" alt="" style="width:200px; height:250px;"/></a>
                        <div class="slide-title">
                            <h4><%# Eval("MovieName").ToString() %>
                        </div>
                        <div class="date-city">
                            <h5><%# Eval("Release_Date").ToString() %></h5>
                          
                            <div class="buy-tickets">
                                <a href="Details.aspx?MovieID=<%# Eval("MovieID").ToString() %>">BUY TICKETS</a>
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
            <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="DataClassesDataContext" Select="new (MovieID, MovieName, Description, Release_Date, MovieImage)" TableName="Movie_Tbls" OrderBy="Release_Date"></asp:LinqDataSource>
        </ul>
	<%--	<ul id="flexiselDemo1" runat="server">
			<li>
				<a href="movies.html"><img src="images/r1.jpg" alt=""/></a>
				<div class="slide-title"><h4>looked up one of the more Contrary to popular </div>
				<div class="date-city">
					<h5>Dec 12-15</h5>
					<h6>Multi-city</h6>
					<div class="buy-tickets">
						<a href="movie-select-show.html">BUY TICKETS</a>
					</div>
				</div>
			</li>
			<li>
				<a href="movies.html"><img src="images/r2.jpg" alt=""/></a>
				<div class="slide-title"><h4>There are many 'variations' belief</h4></div>
				<div class="date-city">
					<h5>Dec 12-15</h5>
					<h6>Multi-city</h6>
					<div class="buy-tickets">
						<a href="movie-select-show.html">BUY TICKETS</a>
					</div>
				</div>
			</li>
			<li>
				<a href="movies.html"><img src="images/r3.jpg" alt=""/></a>
				<div class="slide-title"><h4>Finibus Bonorum et Malorum more 'Contrary'</h4></div>
				<div class="date-city">
					<h5>Dec 12-15</h5>
					<h6>Multi-city</h6>
					<div class="buy-tickets">
						<a href="movie-select-show.html">BUY TICKETS</a>
					</div>
				</div>
			</li>
			<li>
				<a href="movies.html"><img src="images/r4.jpg" alt=""/></a>
				<div class="slide-title"><h4>Lorem Ipsum is simply Bonorum</h4></div>
				<div class="date-city">
					<h5>Dec 12-15</h5>
					<h6>Multi-city</h6>
					<div class="buy-tickets">
						<a href="movie-select-show.html">BUY TICKETS</a>
					</div>
				</div>
			</li>
			<li>
				<a href="movies.html"><img src="images/r5.jpg" alt=""/></a>
				<div class="slide-title"><h4>Lorem Ipsum is simply Bonorum</h4></div>
				<div class="date-city">
					<h5>Dec 12-15</h5>
					<h6>Multi-city</h6>
					<div class="buy-tickets">
						<a href="movie-select-show.html">BUY TICKETS</a>
					</div>
				</div>
			</li>
			<li>
				<a href="movies.html"><img src="images/r6.jpg" alt=""/></a>
				<div class="slide-title"><h4>Lorem Ipsum is simply Bonorum</h4></div>
				<div class="date-city">
					<h5>Dec 12-15</h5>
					<h6>Multi-city</h6>
					<div class="buy-tickets">
						<a href="movie-select-show.html">BUY TICKETS</a>
					</div>
				</div>
			</li>
		</ul>--%>
			
		</div>
    <script type="text/javascript">
        $(window).load(function () {

            $("#flexiselDemo1").flexisel({
                visibleItems: 5,
                animationSpeed: 1000,
                autoPlay: true,
                autoPlaySpeed: 3000,
                pauseOnHover: false,
                enableResponsiveBreakpoints: true,
                responsiveBreakpoints: {
                    portrait: {
                        changePoint: 480,
                        visibleItems: 2
                    },
                    landscape: {
                        changePoint: 640,
                        visibleItems: 3
                    },
                    tablet: {
                        changePoint: 800,
                        visibleItems: 4
                    }
                }
            });
        });
		</script>
		<script type="text/javascript" src="js/jquery.flexisel.js"></script>	
</asp:Content>

