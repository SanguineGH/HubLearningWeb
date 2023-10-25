<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeRequest.aspx.cs" Inherits="HubLearningWeb.Views.MakeRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="../Css/Dashboard.css" rel="stylesheet" />
    <link href="../Css/MakeRequest.css" rel="stylesheet" />
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
                <br />
                <div class="PostRequestHolder">
                    <div class="TopPart">
                        <div class="ImageContainer">
                        <img src="../Medias/Images/PF_placeholder.png" class="RequestImage"/>
                        </div>
                        <div class="HoldInfos">
                            <asp:Label ID="Name" runat="server" Text="Name: Ian Quimming" ></asp:Label>
                            <asp:Label ID="SID" runat="server" Text="Student ID: 19-2020" class="InfoLabel"></asp:Label>
                            <asp:Label ID="Email" runat="server" Text="Email: Ianquimming@gmail.com" class="InfoLabel"></asp:Label>
                            <asp:Label ID="Contact" runat="server" Text="Contact No.: 09123456789" class="InfoLabel"></asp:Label>
                        </div>
                    </div>
                    <hr />
                    <div class="BottomPart">
                        <div class="Strand">
                            <p>Strand</p>
                            <asp:CheckBox ID="CheckBox10" runat="server" OnCheckedChanged="CheckBox10_CheckedChanged" Text="STEM" />
                            <asp:CheckBox ID="CheckBox11" runat="server" Text="ABM"/>
                            <asp:CheckBox ID="CheckBox12" runat="server" Text="HUMSS"/>
                            <asp:CheckBox ID="CheckBox13" runat="server" Text="GAS"/>
                            <asp:CheckBox ID="CheckBox24" runat="server" Text="Tech Voc"/>
                        </div>
                        <div class="Subject">
                            <p>Subject</p>
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="null"/>
                            <asp:CheckBox ID="CheckBox2" runat="server" Text="null"/>
                            <asp:CheckBox ID="CheckBox3" runat="server" Text="null"/>
                            <asp:CheckBox ID="CheckBox4" runat="server" Text="null"/>
                        </div>

                        <div class="Avail">
                            <p>Availability</p>
                            <asp:CheckBox ID="CheckBox14" runat="server" Text="Sunday"/>
                            <asp:CheckBox ID="CheckBox15" runat="server" Text="Monday"/>
                            <asp:CheckBox ID="CheckBox23" runat="server" Text="Tuesday"/>
                            <asp:CheckBox ID="CheckBox16" runat="server" Text="Wednesday"/>
                            <asp:CheckBox ID="CheckBox17" runat="server" Text="Thursday"/>
                            <asp:CheckBox ID="CheckBox21" runat="server" Text="Friday"/>
                            <asp:CheckBox ID="CheckBox22" runat="server" Text="Saturday"/>
                            
                        </div>
                        <div class="Location">
                            <p>Location</p>
                            <asp:CheckBox ID="CheckBox18" runat="server" Text="Home"/>
                            <asp:CheckBox ID="CheckBox19" runat="server" Text="School"/>
                            <asp:CheckBox ID="CheckBox20" runat="server" Text="Public Place"/>
                        </div>

                        <asp:Button ID="Button1" runat="server" Text="Submit" />

                    </div>

                </div>
    

            </div>
        </div>
    </form>
</body>
</html>
