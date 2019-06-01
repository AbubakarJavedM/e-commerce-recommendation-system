<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>
<!DOCTYPE html PUBLIC>

<html>
<head runat="server">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>blender</title>
    
    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link  rel="stylesheet" type="text/css" href="fonts/font-awesome/css/font-awesome.min.css"/>
    <!-- Important Owl stylesheet -->
    

    
    <link href="css/style.css" rel="stylesheet" type="text/css"  />
     
    <script src="js/jquery.js"></script>
    <script type="text/javascript">
        $('.star').hover(function () {
            $(this).prevAll().andSelf().removeClass('fa-star-o').addClass('fa-star');
        });
        $('.star').mouseout(function () {
            $(this).prevAll().andSelf().removeClass('fa-star').addClass('fa-star-o');
        });
        function myfun(x) {
            //var x = ($(this).prevAll().length + 1);
            //alert(x);
            //$(this).prevAll().andSelf().addClass('fa-star');
          ////  x=parseInt(x);
            var s = $('.it');
            for (i = 0; i <parseInt(x); i++)
            {
                $(s[i]).css({ "color": "gold" });
            }

        }
        </script>
<script src="js/myjs.js"></script>
<!-- Include all compiled plugins (below), or include individual files as needed -->
<script src="js/bootstrap.min.js"></script>
<!-- Include js plugin -->
<script src="owl-carousel/owl.carousel.js"></script>
 //////////////////////
    //
    <%--<script>
// Starrr plugin (https://github.com/dobtco/starrr)
var __slice = [].slice;

(function($, window) {
  var Starrr;

  Starrr = (function() {
    Starrr.prototype.defaults = {
      rating: void 0,
      numStars: 5,
      change: function(e, value) {}
    };

    function Starrr($el, options) {
      var i, _, _ref,
        _this = this;

      this.options = $.extend({}, this.defaults, options);
      this.$el = $el;
      _ref = this.defaults;
      for (i in _ref) {
        _ = _ref[i];
        if (this.$el.data(i) != null) {
          this.options[i] = this.$el.data(i);
        }
      }
      this.createStars();
      this.syncRating();
      this.$el.on('mouseover.starrr', 'span', function(e) {
        return _this.syncRating(_this.$el.find('span').index(e.currentTarget) + 1);
      });
      this.$el.on('mouseout.starrr', function() {
        return _this.syncRating();
      });
      this.$el.on('click.starrr', 'span', function(e) {
        return _this.setRating(_this.$el.find('span').index(e.currentTarget) + 1);
      });
      this.$el.on('starrr:change', this.options.change);
    }

    Starrr.prototype.createStars = function() {
      var _i, _ref, _results;

      _results = [];
      for (_i = 1, _ref = this.options.numStars; 1 <= _ref ? _i <= _ref : _i >= _ref; 1 <= _ref ? _i++ : _i--) {
        _results.push(this.$el.append("<span i class='glyphicon .glyphicon-star-empty'></span>"));
      }
      return _results;
    };

    Starrr.prototype.setRating = function(rating) {
      if (this.options.rating === rating) {
        rating = void 0;
      }
      this.options.rating = rating;
      this.syncRating();
      return this.$el.trigger('starrr:change', rating);
    };

    Starrr.prototype.syncRating = function(rating) {
      var i, _i, _j, _ref;

      rating || (rating = this.options.rating);
      if (rating) {
        for (i = _i = 0, _ref = rating - 1; 0 <= _ref ? _i <= _ref : _i >= _ref; i = 0 <= _ref ? ++_i : --_i) {
          this.$el.find('span').eq(i).removeClass('glyphicon-star-empty').addClass('glyphicon-star');
        }
      }
      if (rating && rating < 5) {
        for (i = _j = rating; rating <= 4 ? _j <= 4 : _j >= 4; i = rating <= 4 ? ++_j : --_j) {
          this.$el.find('span').eq(i).removeClass('glyphicon-star').addClass('glyphicon-star-empty');
        }
      }
      if (!rating) {
        return this.$el.find('span').removeClass('glyphicon-star').addClass('glyphicon-star-empty');
      }
    };

    return Starrr;

  })();
  return $.fn.extend({
    starrr: function() {
      var args, option;

      option = arguments[0], args = 2 <= arguments.length ? __slice.call(arguments, 1) : [];
      return this.each(function() {
        var data;

        data = $(this).data('star-rating');
        if (!data) {
          $(this).data('star-rating', (data = new Starrr($(this), option)));
        }
        if (typeof option === 'string') {
          return data[option].apply(data, args);
        }
      });
    }
  });
})(window.jQuery, window);

$(function() {
  return $(".starrr").starrr();
});

$(document).ready(function() {
      
    $('#stars').on('starrr:change', function(e, value){
        $('#count').html(value);
       /// $(this).click;
       // alert(value);
    });
  
    $('#stars-existing').on('starrr:change', function(e, value){
        $('#count-existing').html(value);
       /// alert(value);
    });
});

        </script>--%>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/json2/20130526/json2.min.js"></script>

    <script type="text/javascript">
        function me(x){
            var e = document.getElementById(x);
            var given = e.options[e.selectedIndex].value;
            var someSession = "<%=Session["user"].ToString()%>";
       
            //str;
            $.ajax({
                type: "POST",
                url: "WebForm2.aspx/addRate",
                ///data: "{id:"+x+",rating:"+given+",name:"+someSession+"}",
                data:JSON.stringify({id:x,rating:given,name:someSession}),
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               success: alert("Product Successfully Rated"),
                failure: function(response) {
                    alert("You have allready rated this product");
                }
           });
        }
        </script>
    ///////////////////// 
 
</head>
<body>
    
    <form runat="server"><asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    <div class="row align">
        <div class="col-md-10">
            <nav class="navbar navbar-inverse">
              <div class="container-fluid">
                <div class="navbar-header">
                  <a class="navbar-brand" href="#">SearchMOBILE</a>
                </div>
                <ul class="nav navbar-nav">
                  <li class="active"><a href="#">Home</a></li>
                  <li><a href="WebForm4.aspx">About us</a></li>
                </ul>
                <div class="navbar-form navbar-left" style="margin:2px;">
                    <input id="str" type="text" runat="server" style="width:75%;font-size:20px;border-radius:23px;padding-left:10px;margin-top:9px;"/>
                    <asp:Button runat="server"  OnClick="searchbtn_ServerClick" id="searchbtn1" class="btn btn-sm btn-primary" Text="Search" style="margin-left:5px;border-radius:5px;"/>
                </div>
              </div>
            </nav>
            <!-- <div class="input-group custom-search-form">
                 
                            <input id="search" type="text" runat="server" class="form-control"/>
                            <span class="input-group-btn">
                            <asp:Button runat="server" onclick="searchbtn_ServerClick" id="searchbtn" class="btn btn-primary myy" Text="SEARCH"/>
                            <span class="glyphicon glyphicon-search"></span>
                           </span>
                        </div><!-- /input-group -->  
        </div>
    </div>
        
        
    <div class="row align">
        <div class="col-md-10">
        
            <table class="points_table" width="100%">
                <thead>
                    <tr>
                        <th class="col-lg-3">Image</th>
                        <th class="col-lg-3">Product Name</th>
                        <th class="col-lg-1">Price</th>
                        <th class="col-lg-1">Rating1</th>
                        <th class="col-lg-2">Rating2</th>
                        <th class="col-lg-2">Visit</th>
                    </tr>
                </thead>
    
                <tbody id="tabahi"  runat="server" class="">
                  
                        
                 <asp:Label class="mtr" ID="Label1" runat="server" Text=""></asp:Label>
                  <asp:Label class="mtr" ID="Label3" runat="server" Text=""></asp:Label>
                </tbody>

            </table>
          
            </div>
        </div>
        </form>
<%--<script src="js/jquery.js"></script>
    <script type="text/javascript">
        $('.star').hover(function () {
            $(this).prevAll().andSelf().removeClass('fa-star-o').addClass('fa-star');
        });
        $('.star').mouseout(function () {
            $(this).prevAll().andSelf().removeClass('fa-star').addClass('fa-star-o');
        });
        function myfun(x) {
            //var x = ($(this).prevAll().length + 1);
            //alert(x);
            //$(this).prevAll().andSelf().addClass('fa-star');
          ////  x=parseInt(x);
            var s = $('.it');
            for (i = 0; i <parseInt(x); i++)
            {
                $(s[i]).prevAll().andSelf().removeClass('fa-star-o').addClass('fa-star');
            }

        }
        </script>
<script src="js/myjs.js"></script>
<!-- Include all compiled plugins (below), or include individual files as needed -->
<script src="js/bootstrap.min.js"></script>
<!-- Include js plugin -->
<script src="owl-carousel/owl.carousel.js"></script>--%>
</body>
</html>
