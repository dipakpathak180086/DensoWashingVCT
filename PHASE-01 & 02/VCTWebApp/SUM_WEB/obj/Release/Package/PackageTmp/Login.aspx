<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VCTWebApp.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!--<meta name="viewport" content="width=device-width, initial-scale=1">-->
    <title>VCT TREACEABILITY SYSTEM</title>
    <script type="text/javascript" src="../../JSFiles/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="../../JSFiles/bootstrap.min.js"></script>
    <link rel="stylesheet" href="JSFiles/bootstrap.min.css" media="screen" />
    <link href="dist/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script src="JSFiles/bootstrap.min.js"></script>

    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
    <style type="text/css">
        /*
 * Specific styles of signin component
 */
        /*
 * General styles
 */
        body, html {
            height: 100%;
            background-repeat: no-repeat;
            background-image: linear-gradient(rgb(193,218,232), rgb(255,255,255));
            font-family: Verdana
        }

        .card-container.card {
            max-width: 350px;
            padding: 40px 40px;
            font-family: Verdana
        }

        .btn {
            font-weight: 700;
            height: 36px;
            -moz-user-select: none;
            -webkit-user-select: none;
            user-select: none;
            cursor: default;
            font-family: Verdana
        }

        /*
 * Card component
 */
        .card {
            background-color: #F7F7F7;
            /* just in case there no content*/
            padding: 20px 25px 30px;
            margin: 0 auto 25px;
            margin-top: 50px;
            margin-left: 650px;
            /* shadows and rounded borders */
            -moz-border-radius: 2px;
            -webkit-border-radius: 2px;
            border-radius: 2px;
            -moz-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
            -webkit-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
            box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
        }

        .profile-img-card {
            width: 96px;
            height: 96px;
            margin: 0 auto 10px;
            display: block;
            -moz-border-radius: 50%;
            -webkit-border-radius: 50%;
            border-radius: 50%;
        }

        /*
 * Form styles
 */
        .profile-name-card {
            font-size: 16px;
            font-weight: bold;
            text-align: center;
            margin: 10px 0 0;
            min-height: 1em;
        }

        .reauth-email {
            display: block;
            color: #404040;
            line-height: 2;
            margin-bottom: 10px;
            font-size: 14px;
            text-align: center;
            overflow: hidden;
            text-overflow: ellipsis;
            white-space: nowrap;
            -moz-box-sizing: border-box;
            -webkit-box-sizing: border-box;
            box-sizing: border-box;
        }

        .form-signin #inputEmail,
        .form-signin #inputPassword {
            direction: ltr;
            height: 44px;
            font-size: 16px;
        }

        .form-signin input[type=email],
        .form-signin input[type=password],
        .form-signin input[type=text],
        .form-signin button {
            width: 100%;
            display: block;
            margin-bottom: 10px;
            z-index: 1;
            position: relative;
            -moz-box-sizing: border-box;
            -webkit-box-sizing: border-box;
            box-sizing: border-box;
        }

        .form-signin .form-control:focus {
            border-color: rgb(104, 145, 162);
            outline: 0;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgb(104, 145, 162);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgb(104, 145, 162);
        }

        .btn.btn-signin {
            /*background-color: #4d90fe; */
            background-color: #FF0000;
            /* background-color: linear-gradient(rgb(104, 145, 162), rgb(12, 97, 33));*/
            padding: 0px;
            font-weight: 700;
            font-size: 14px;
            height: 36px;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            border-radius: 3px;
            border: none;
            -o-transition: all 0.218s;
            -moz-transition: all 0.218s;
            -webkit-transition: all 0.218s;
            transition: all 0.218s;
        }

            .btn.btn-signin:hover,
            .btn.btn-signin:active,
            .btn.btn-signin:focus {
                background-color: red;
            }

        .forgot-password {
            color: rgb(104, 145, 162);
        }

            .forgot-password:hover,
            .forgot-password:active,
            .forgot-password:focus {
                color: rgb(12, 97, 33);
            }

        .mid-wrap {
            padding: 0 30px 0;
            display: inline-block;
            vertical-align: top;
            width: 100%;
            margin: 25px 0 0 0;
        }

        .login-bg-box {
            background: url('Images/Login-bg.png') no-repeat 0 0;
            height: 100vh;
            display: flex;
            align-items: center;
            background-size: 100% 100%;
            background-position: center;
            margin: 0;
            position: relative;
        }

        .login-wrap-box {
            width: 330px;
            transform: translate(-50%, -50%);
            top: 47%;
            left: 65%;
            position: absolute;
            border-radius: 12px;
            border: solid 1px #d1d1d1;
            background-color: #cefefe;
            padding: 15px 25px;
        }

        .left-logo {
            position: absolute;
            top: 25px;
        }

        .center-head {
            margin-right: 950px
        }
        .login-wrap-box .iot-logo {
    text-align: left;
    width: 100%;
    display: inline-block;
}

.text-logo {
    margin: 5px 0 0 30px;
    float: left;
}

    .text-logo h4 {
        font-size: 22px;
        font-family: Calibri;
        font-weight:bold
    }

    .text-logo p {
        font-weight: bold;
        font-family: Verdana;
        font-size: 20px;
    }
    </style>
</head>
<body>
    
    <div class="mid-wrap login-bg-box">
       
        <div class="mid-wrap">
            <form runat="server">
                 
                <div class="left-logo">
             
             <img src="Images/Denso-logo.png" width="100px" alt="STMS" >
                    <h1>VCT Traceability System</h1>
              
            </div>
                
               
                <div class="card card-container">
                                            <div class="logo-main iot-logo">
    <div class="text-logo">
        <h4>Login User Id & Password</h4>
    </div>
</div>
                    <img id="profile-img" class="profile-img-card" src="//ssl.gstatic.com/accounts/ui/avatar_2x.png" //>
                    <p id="profile-name" class="profile-name-card"></p>
                    <form  method="post">
                        
                        <span id="reauth-email" class="reauth-email"></span>

                        </i>
                <asp:TextBox ID="txtUserId" class="form-control" runat="server" required autofocus></asp:TextBox>
                        </i>
                <br />
                        <asp:TextBox ID="txtPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        <br />

                        <br />



                        <%--   <button class="btn btn-lg btn-primary btn-block btn-signin" id="btnsubmit" runat="server" type="submit">Sign in</button>--%>
                        <asp:Button class="btn btn-lg btn-primary btn-block btn-signin" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                        <br />


                    </form>

                </div>
            </form>
        </div>
    </div>
</body>
</html>
