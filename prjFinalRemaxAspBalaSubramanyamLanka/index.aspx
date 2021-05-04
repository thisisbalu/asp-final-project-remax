<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="prjFinalRemaxAspBalaSubramanyamLanka.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/index.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" style="margin-top: -1rem!important;">

        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class=""></li>
                <li data-target="#myCarousel" data-slide-to="1" class=""></li>
                <li data-target="#myCarousel" data-slide-to="2" class="active"></li>
            </ol>
            <div class="carousel-inner">
                <div class="carousel-item">
                    <img class="first-slide" src="Images/Website/banner1.jpg" alt="First slide">
                    <div class="container">
                        <div class="carousel-caption text-left">
                            <h1>Example headline.</h1>
                            <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
                        </div>
                    </div>
                </div>
                <div class="carousel-item active carousel-item-left">
                    <img class="second-slide" src="Images/Website/banner2.jpg" alt="Second slide">
                    <div class="container">
                        <div class="carousel-caption">
                            <h1>Another example headline.</h1>
                            <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
                        </div>
                    </div>
                </div>
                <div class="carousel-item carousel-item-next carousel-item-left">
                    <img class="third-slide" src="Images/Website/banner3.jpg" alt="Third slide">
                    <div class="container">
                        <div class="carousel-caption text-right">
                            <h1>One more for good measure.</h1>
                            <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
                        </div>
                    </div>
                </div>
            </div>
            <a class="carousel-control-prev" href="#myCarousel" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#myCarousel" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>


        <!-- Marketing messaging and featurettes
      ================================================== -->
        <!-- Wrap the rest of the page in another container to center all the content. -->

        <div class="container marketing">


            <!-- START THE FEATURETTES -->

            <hr class="featurette-divider">

            <div class="row featurette">
                <div class="col-md-7">
                    <h2 class="featurette-heading"><span class="text-muted">We are here for you!</span></h2>
                    <p class="lead">Real estate transactions are still able to be conducted in many markets with new safety measures put into place. Regardless of location, RE/MAX agents are ready to support you however they can. To learn more, contact a local RE/MAX professional who can help.</p>
                </div>
                <div class="col-md-5">
                    <img class="featurette-image img-fluid mx-auto" data-src="holder.js/500x500/auto" alt="500x500" style="width: 500px; height: 500px;" src="Images/Website/intro1.jpg" data-holder-rendered="true">
                </div>
            </div>

            <hr class="featurette-divider">

            <div class="row featurette">
                <div class="col-md-7 order-md-2">
                    <h2 class="featurette-heading"><span class="text-muted">Dream Home Come True!</span></h2>
                    <p class="lead">Finding your dream home just got easier. Our home search app allows you to continue your search for available listings from the convenience of your smartphone or tablet — anytime, anywhere. Save homes you love, request information, schedule showings, and receive push notifications within minutes of homes hitting the market.</p>
                </div>
                <div class="col-md-5 order-md-1">
                    <img class="featurette-image img-fluid mx-auto" data-src="holder.js/500x500/auto" alt="500x500" src="Images/Website/intro2.jpg" data-holder-rendered="true" style="width: 500px; height: 500px;">
                </div>
            </div>

            <hr class="featurette-divider">

            <div class="row featurette">
                <div class="col-md-7">
                    <h2 class="featurette-heading"><span class="text-muted">Get the Mobile APP!</span></h2>
                    <p class="lead">They’re most known, however, for being dependable and a shoulder to lean on for friends, family and new acquaintances alike. People born in April are fiercely loyal and go far out of their way to help others. With this mindset and a packed schedule, it only makes sense that they keep a tidy home and stay organized</p>
                </div>
                <div class="col-md-5">
                    <img class="featurette-image img-fluid mx-auto" data-src="holder.js/500x500/auto" alt="500x500" src="Images/Website/intro3.jpg" data-holder-rendered="true" style="width: 500px; height: 500px;">
                </div>
            </div>
            <!-- /END THE FEATURETTES -->

        </div>
        <!-- /.container -->
        <script src="Lib/jquery/jquery.slim.min.js"></script>
        <script src="Lib/popper/umd/popper.min.js"></script>
        <script src="Lib/bootstrap/js/bootstrap.min.js"></script>
    </main>
</asp:Content>
