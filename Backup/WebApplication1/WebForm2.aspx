<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>blender</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome/css/font-awesome.min.css"/>
    <!-- Important Owl stylesheet -->
    <link rel="stylesheet" href="owl-carousel/owl.carousel.css">
    <link rel="stylesheet" href="owl-carousel/owl.theme.css">

    <link href="css/style.css" rel="stylesheet">
    
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>

    <div class="row align">
        <div class="col-md-8">
                <div class="input-group custom-search-form">
                    <input id="search" type="text" runat="server" class="form-control"/>
                    <span class="input-group-btn">
                    <button id="searchbtn" runat="server" class="btn btn-primary" type="button">
                    <span class="glyphicon glyphicon-search"></span>
                    </button>
                     </span>
                </div><!-- /input-group -->
        </div>
    </div>

    <div class="row align">
        <div class="col-md-8">
            <table class="points_table" width="100%">
                <thead>
                    <tr>
                        <th class="col-lg-1">#</th>
                        <th class="col-lg-5">Product Name</th>
                        <th class="col-lg-2">Price</th>
                        <th class="col-lg-2">Rating1</th>
                        <th class="col-lg-2">Rating2</th>
                    </tr>
                </thead>
    
                <tbody class="">
                    <tr class="odd">
                        <td class="col-lg-1">1</td>
                        <td class="col-lg-5">Test Points</td>
                        <td class="col-lg-2">10</td>
                        <td class="col-lg-2">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="star-rating">
                                        <span class="fa fa-star-o" data-rating="1"></span>
                                        <span class="fa fa-star-o" data-rating="2"></span>
                                        <span class="fa fa-star-o" data-rating="3"></span>
                                        <span class="fa fa-star-o" data-rating="4"></span>
                                        <span class="fa fa-star-o" data-rating="5"></span>
                                        <input type="hidden" name="whatever1" class="rating-value" value="2.56">
                                    </div>
                                </div>
                            </div>

                        </td>
                        <td class="col-lg-2">
                            <div class="row">
                                    <div class="col-lg-12">
                                        <div class="star-rating">
                                  
                                            <span class="fa fa-star-o" data-rating="1"></span>
                                            <span class="fa fa-star-o" data-rating="2"></span>
                                            <span class="fa fa-star-o" data-rating="3"></span>
                                            <span class="fa fa-star-o" data-rating="4"></span>
                                            <span class="fa fa-star-o" data-rating="5"></span>
                                            <input id="Hidden1" type="hidden" runat="server" name="whatever1" class="rating-value" value="2.56"/>
                                        </div>
                                    </div>
                                </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            </div>
        </div>

<script src="js/jquery.js"></script>
<script src="js/myjs.js"></script>
<!-- Include all compiled plugins (below), or include individual files as needed -->
<script src="js/bootstrap.min.js"></script>
<!-- Include js plugin -->
<script src="owl-carousel/owl.carousel.js"></script>
</body>
</html>
