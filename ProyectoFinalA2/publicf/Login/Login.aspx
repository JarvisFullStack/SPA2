<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoFinalA2.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/> 
<link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" type="text/css"/> 
<link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css" type="text/css" rel="stylesheet" />

<script
  src="https://code.jquery.com/jquery-3.4.1.min.js"
  integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo="
  crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

<script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js" type="text/javascript"></script>
    <title></title>

	<link rel="stylesheet" type="text/css" href="loginstyle.css"/>

</head>

<body>
	

  <div class="container">
    <div class="row">
      <div class="col-lg-10 col-xl-9 mx-auto">
        <div class="card card-signin flex-row my-5">
          <div class="card-img-left d-none d-md-flex">
             <!-- Background image for card set in CSS! -->
          </div>
          <div class="card-body">
            <h5 class="card-title text-center">Login</h5>
            <form runat="server" class="form-signin">
             

              <div class="form-label-group">
                <asp:TextBox runat="server" type="email" ID="textboxEmail" class="form-control" placeholder="Email address" required autofocus/>
                <label for="textboxEmail">Email address</label>
              </div>
              
              <hr />

              <div class="form-label-group">
                <asp:TextBox runat="server" type="password" ID="textboxPassword" class="form-control" placeholder="Password" required />
                <label for="textboxPassword">Password</label>
              </div>
              
          
              <asp:Button ID="LoginButton" runat="server" text="Login"  OnClick="LoginButton_Click" class="btn btn-lg btn-primary btn-block text-uppercase" type="submit"/>
				<a class="d-block text-center mt-2 small" href="Register.aspx">Register</a>
              <hr class="my-4" />
             
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
	

</body>
</html>

