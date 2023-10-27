<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="HubLearningWeb.Views.Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="../Css/Dashboard.css" rel="stylesheet" />
    <link href="../Css/Account.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
          <div class="Dashboard">
            <div class="IconNavigation">
                <div class="Icon">
                    <img src="../Medias/Images/PF_placeholder.png" class="IconImage" />
                </div>
                <div class="Navigation">
                    <div class="dropdown">
                        <button class="dropbtn">Bulletin</button>
                        <div class="dropdown-content">
                            <a href="BulletinTutor.aspx">Tutor Bulletin</a>
                            <a href="BulletinTutee.aspx">Tutee Bulletin</a>
                        </div>
                    </div>
                    <div class="dropdown">
                        <button class="dropbtn">Notifications</button>
                        <div class="dropdown-content">
                            <a href="DashBoard.aspx">Tutor Notification</a>
                            <a href="DashBoard.aspx">Tutee Notification</a>
                        </div>
                    </div>
                    <div class="dropdown">
                        <button class="dropbtn">Request</button>
                        <div class="dropdown-content">
                            <a href="MakeRequest.aspx">Make a Request</a>
                        </div>
                    </div>
                    <div class="dropdown">
                        <button class="dropbtn">Account</button>
                        <div class="dropdown-content">
                            <a href="Account.aspx">Account</a>
                            <a href="DashBoard.aspx">Progress Tracking</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="Content">
            
                 <div class="GrandHolder">
                   <div class="TopPart">
                    <div class="ImageHolder">
                        <img src="../Images/ako.jpg" / class="ImagePF"/>
                    </div>
                    <div class="InfoHolder">
                        <p>Name: Ian Quiming </p>
                        <p>Student ID: 21-2323</p>
                        <p>Age: 21 </p>
                        <p>Sex: Male  </p>
                        <p>Location: Quezon City </p>
                        <p>Year Level: G12  </p>
                    </div>
                    <div class="ContactHolder">
                        <h2>Contacts</h2>
                        <p>Email: IanQuiming@gmail.com</p>
                        <p>Contact Number: 09123456789</p>
                        <p>Facebook: Ian Quiming</p>
                    </div>
                    <div class="Logout">
                        <asp:Button class="blog" ID="logout" runat="server" Text="Logout" OnClick="logout_Click"/>
                    </div>
                </div>
                        <div class="BottomPart">
                        <h1>Bio comes here</h1>
                        <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris fringilla eget libero ac finibus. Integer bibendum orci at augue facilisis, interdum sodales ante fermentum. Ut ac felis non lacus ornare pellentesque. Maecenas eu scelerisque lorem, id placerat tellus. Suspendisse rhoncus, nunc eget vestibulum sodales, lacus nibh dictum libero, eu laoreet tortor nisi non felis. Fusce venenatis tempor aliquam. Ut sed quam nec nulla sodales vulputate. Mauris ultrices dignissim tortor, eget egestas nunc bibendum ac. Integer ultrices, magna sed facilisis interdum, arcu metus suscipit risus, at sodales lorem arcu a magna.

                        </p>
                    </div>
                 </div>





            </div>
        </div>
    </form>
</body>
</html>
