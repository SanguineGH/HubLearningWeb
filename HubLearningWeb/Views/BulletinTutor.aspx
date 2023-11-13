<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulletinTutor.aspx.cs" Inherits="HubLearningWeb.Views.BulletinTutor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title></title>
    <link href="../Css/Bulletin.css" rel="stylesheet" />
    <link href="../Css/Dashboard.css" rel="stylesheet" />
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
                            <a href="TutorNotif.aspx">Tutor Notification</a>
                            <a href="TuteeNotif.aspx">Tutee Notification</a>
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
                            <a href="Progress.aspx">Progress Tracking</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="Content">
                                <div class="MainContentHolder">
                <div class="FilterSide">
                    <p> FILTERS </p>
                    <div class="Strands">
                        <p> Strand </p>
                        <asp:RadioButton ID="STEM" runat="server" text="STEM"/>
                        <asp:RadioButton ID="ABM" runat="server" text="ABM"/>
                        <asp:RadioButton ID="HUMSS" runat="server" text="HUMSS"/>
                        <asp:RadioButton ID="GAS" runat="server" text="GAS"/>
                        <asp:RadioButton ID="IT" runat="server" text="IT"/>
                    </div>
                    <div class="Subjects">
                        <p> Subjects </p>
                        <div class="Holder">
                        <asp:RadioButton ID="Subject1" runat="server" text="Subject 1"/>
                            </div>
                        <div class="Holder">
                        <asp:RadioButton ID="Subject2" runat="server" text="Subject 2"/>
                            </div>
                        <div class="Holder">
                        <asp:RadioButton ID="Subject3" runat="server" text="Subject 3"/>
                            </div>
                        <div class="Holder">
                        <asp:RadioButton ID="Subject4" runat="server" text="Subject 4"/>
                            </div>
                        <div class="Holder">
                        <asp:RadioButton ID="Subject5" runat="server" text="Subject 5"/>
                            </div>
                    </div>
                    <div class="Yearlvl">
                        <p> Year Level </p>
                        <div class="Holder">
                        <asp:RadioButton ID="FirstLVL" runat="server" text="First Year" />
                            </div>
                        <div class="Holder">
                        <asp:RadioButton ID="SecondLVL" runat="server" text="Second Year" />
                            </div>
                    </div>
                    <div class="Availability">
                        <p> Availability </p>
                        <div class="Holder">
                        <asp:CheckBox ID="Monday" runat="server" text="Monday" value="Monday"/>
                            </div>
                        <div class="Holder">
                        <asp:CheckBox ID="Tuesday" runat="server" text="Tuesday" value="Tuesday"/>
                            </div>
                        <div class="Holder">
                        <asp:CheckBox ID="Wednesday" runat="server" text="Wednesday" value="Wednesday"/>
                            </div>
                        <div class="Holder">
                        <asp:CheckBox ID="Thursday" runat="server" text="Thursday" value="Thursday"/>
                            </div>
                        <div class="Holder">
                        <asp:CheckBox ID="Friday" runat="server" text="Friday" value="Friday"/>
                            </div>
                        <div class="Holder">
                        <asp:CheckBox ID="Saturday" runat="server" text="Saturday" value="Saturday"/>
                            </div>
                        <div class="Holder">
                        <asp:CheckBox ID="Sunday" runat="server" text="Sunday" value="Sunday"/>
                            </div>
                    </div>
                    <div class="Location">
                        <p> Location </p>
                        <div class="Holder">
                        <asp:CheckBox ID="Home" runat="server" text="Home" value="Home"/>
                            </div>
                        <div class="Holder">
                        <asp:CheckBox ID="School" runat="server" text="School" value="School"/>
                            </div>
                        <div class="Holder">
                        <asp:CheckBox ID="Other" runat="server" text="Other Places" value="Other Places"/>
                            </div>
                    </div>
                    <br />
                    <br />
                    <div class="ButtonLoc">
                        <asp:Button ID="Submit" runat="server" Text="Submit" />
                    </div>
                </div>
                <div class="CardSide">
                    <div class="BullTitle">
                        <p>TUTOR BULLETIN</p>
                    </div>
                    <div class="CardSideContainer">
                         <asp:Repeater ID="CardRepeater" runat="server">
                                <ItemTemplate>
                                    <td class="Cards">
                                        <div class="CardDiv">
                                            <div class="CardImage">
                                                <img src="../Images/PF_placeholder.png" class="CardDP" />
                                                <br />
                                                <br />
                                                <asp:HiddenField ID="HiddenRid" runat="server" Value='<%# Eval("rid") %>' />
                                                <asp:Button ID="MoreButton" runat="server" Text="More" class="MoreButton" OnClientClick='<%# "showDetails(" + Eval("rid") + "); return false;" %>' />
                                                <asp:Button ID="ConnectButton" runat="server" Text="Connect" class="ConnectButton" OnClick="ConnectNow_Click" />
                                            </div>
                                            <div class="CardInfo">
                                                <asp:Label ID="CardName" runat="server" Text='<%# Eval("name") %>' class="label"></asp:Label>
                                                <asp:Label ID="CardTeaching" runat="server" Text='<%# Eval("looking") %>' class="label"></asp:Label>
                                                <asp:Label ID="CardStrand" runat="server" Text='<%# Eval("strand") %>' class="label"></asp:Label>
                                                <asp:Label ID="CardSubject" runat="server" Text='<%# Eval("subject") %>' class="label"></asp:Label>
                                                <asp:Label ID="CardAvailability" runat="server" Text='<%# Eval("availability") %>' class="label"></asp:Label>
                                                <asp:Label ID="CardLocation" runat="server" Text='<%# Eval("location") %>' class="label"></asp:Label>
                                            </div>
                                        </div>
                                    </td>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                                    </div>
            </div>
        </div>
    </form>
</body>
</html>

