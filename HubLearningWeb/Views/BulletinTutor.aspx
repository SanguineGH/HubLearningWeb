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
                    <table style="width: 100%;" class="CardHolder">
                        <tr>
                            <td class="Cards">
                                <div class="CardDiv">
                                <div class="CardImage">
                                <img src="../Images/PF_placeholder.png" class="CardDP"/>
                                    <br />
                                   <br />
                                <asp:Button ID="MoreButton1" runat="server" Text="More" class="MoreButton" />
                                    </div>
                                <div class="CardInfo">                                 
                                    <asp:Label ID="CardName1" runat="server" Text="Name:" class="label"></asp:Label>
                                    <asp:Label ID="CardStrand1" runat="server" Text="Strand:" class="label"></asp:Label>
                                    <asp:Label ID="CardSubject1" runat="server" Text="Subject:" ></asp:Label>
                                </div>
                               </div>
                            </td>
                             <td class="Cards">
                                <div class="CardDiv">
                                <div class="CardImage">
                                <img src="../Images/PF_placeholder.png" class="CardDP"/>
                                    <br />
                                   <br />
                                <asp:Button ID="MoreButton2" runat="server" Text="More" class="MoreButton" />
                                    </div>
                                <div class="CardInfo">                                 
                                    <asp:Label ID="CardName2" runat="server" Text="Name:" class="label"></asp:Label>
                                    <asp:Label ID="CardStrand2" runat="server" Text="Strand:" class="label"></asp:Label>
                                    <asp:Label ID="CardSubject2" runat="server" Text="Subject:" ></asp:Label>
                                </div>
                               </div>
                            </td>
                             <td class="Cards">
                                <div class="CardDiv">
                                <div class="CardImage">
                                <img src="../Images/PF_placeholder.png" class="CardDP"/>
                                    <br />
                                   <br />
                                <asp:Button ID="MoreButton3" runat="server" Text="More" class="MoreButton" />
                                    </div>
                                <div class="CardInfo">                                 
                                    <asp:Label ID="CardName3" runat="server" Text="Name:" class="label"></asp:Label>
                                    <asp:Label ID="CardStrand3" runat="server" Text="Strand:" class="label"></asp:Label>
                                    <asp:Label ID="CardSubject3" runat="server" Text="Subject:" ></asp:Label>
                                </div>
                               </div>
                            </td>
                        </tr>
                        <tr>
                             <td class="Cards">
                                <div class="CardDiv">
                                <div class="CardImage">
                                <img src="../Images/PF_placeholder.png" class="CardDP"/>
                                    <br />
                                   <br />
                                <asp:Button ID="MoreButton4" runat="server" Text="More" class="MoreButton" />
                                    </div>
                                <div class="CardInfo">                                 
                                    <asp:Label ID="CardName4" runat="server" Text="Name:" class="label"></asp:Label>
                                    <asp:Label ID="CardStrand4" runat="server" Text="Strand:" class="label"></asp:Label>
                                    <asp:Label ID="CardSubject4" runat="server" Text="Subject:" ></asp:Label>
                                </div>
                               </div>
                            </td>
                             <td class="Cards">
                                <div class="CardDiv">
                                <div class="CardImage">
                                <img src="../Images/PF_placeholder.png" class="CardDP"/>
                                    <br />
                                   <br />
                                <asp:Button ID="MoreButton5" runat="server" Text="More" class="MoreButton" />
                                    </div>
                                <div class="CardInfo">                                 
                                    <asp:Label ID="CardName5" runat="server" Text="Name:" class="label"></asp:Label>
                                    <asp:Label ID="CardStrand5" runat="server" Text="Strand:" class="label"></asp:Label>
                                    <asp:Label ID="CardSubject5" runat="server" Text="Subject:" ></asp:Label>
                                </div>
                               </div>
                            </td>
                             <td class="Cards">
                                <div class="CardDiv">
                                <div class="CardImage">
                                <img src="../Images/PF_placeholder.png" class="CardDP"/>
                                    <br />
                                   <br />
                                <asp:Button ID="MoreButton6" runat="server" Text="More" class="MoreButton" />
                                    </div>
                                <div class="CardInfo">                                 
                                    <asp:Label ID="CardName6" runat="server" Text="Name:" class="label"></asp:Label>
                                    <asp:Label ID="CardStrand6" runat="server" Text="Strand:" class="label"></asp:Label>
                                    <asp:Label ID="CardSubject6" runat="server" Text="Subject:" ></asp:Label>
                                </div>
                               </div>
                            </td>
                        </tr>
                        <tr>
                             <td class="Cards">
                                <div class="CardDiv">
                                <div class="CardImage">
                                <img src="../Images/PF_placeholder.png" class="CardDP"/>
                                    <br />
                                   <br />
                                <asp:Button ID="MoreButton7" runat="server" Text="More" class="MoreButton" />
                                    </div>
                                <div class="CardInfo">                                 
                                    <asp:Label ID="CardName7" runat="server" Text="Name:" class="label"></asp:Label>
                                    <asp:Label ID="CardStrand7" runat="server" Text="Strand:" class="label"></asp:Label>
                                    <asp:Label ID="CardSubject7" runat="server" Text="Subject:" ></asp:Label>
                                </div>
                               </div>
                            </td>
                             <td class="Cards">
                                <div class="CardDiv">
                                <div class="CardImage">
                                <img src="../Images/PF_placeholder.png" class="CardDP"/>
                                    <br />
                                   <br />
                                <asp:Button ID="MoreButton8" runat="server" Text="More" class="MoreButton" />
                                    </div>
                                <div class="CardInfo">                                 
                                    <asp:Label ID="CardName8" runat="server" Text="Name:" class="label"></asp:Label>
                                    <asp:Label ID="CardStrand8" runat="server" Text="Strand:" class="label"></asp:Label>
                                    <asp:Label ID="CardSubject8" runat="server" Text="Subject:" ></asp:Label>
                                </div>
                               </div>
                            </td>
                             <td class="Cards">
                                <div class="CardDiv">
                                <div class="CardImage">
                                <img src="../Images/PF_placeholder.png" class="CardDP"/>
                                    <br />
                                   <br />
                                <asp:Button ID="MoreButton9" runat="server" Text="More" class="MoreButton" />
                                    </div>
                                <div class="CardInfo">                                 
                                    <asp:Label ID="CardName9" runat="server" Text="Name:" class="label"></asp:Label>
                                    <asp:Label ID="CardStrand9" runat="server" Text="Strand:" class="label"></asp:Label>
                                    <asp:Label ID="CardSubject9" runat="server" Text="Subject:" ></asp:Label>
                                </div>
                               </div>
                            </td>
                        </tr>
                    </table>
            </div>
        </div>
    </form>
</body>
</html>

