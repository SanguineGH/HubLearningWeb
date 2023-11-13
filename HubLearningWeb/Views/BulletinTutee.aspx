﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulletinTutee.aspx.cs" Inherits="HubLearningWeb.Views.BulletinTutee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title></title>
    <link href="../Css/Bulletin.css" rel="stylesheet" />
    <link href="../Css/Dashboard.css" rel="stylesheet" />
    <style>
        .HiddenDiv {
            display: none;
            position: fixed;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            width: 50%;
            background-color: white;
            padding: 20px;
            z-index: 2;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .HiddenDiv img {
            width: 50%;
            height: auto;
        }

        .BottomLayer {
            display: none;
            position: fixed;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            width: 50%;
            background-color: white;
            padding: 20px;
            z-index: 1;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
    </style>
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
                            <asp:RadioButton ID="STEM" runat="server" Text="STEM"/>
                            <asp:RadioButton ID="ABM" runat="server" Text="ABM"/>
                            <asp:RadioButton ID="HUMSS" runat="server" Text="HUMSS"/>
                            <asp:RadioButton ID="GAS" runat="server" Text="GAS"/>
                            <asp:RadioButton ID="IT" runat="server" Text="IT"/>
                        </div>
                        <div class="Subjects">
                            <p> Subjects </p>
                            <div class="Holder">
                                <asp:RadioButton ID="Subject1" runat="server" Text="Subject 1"/>
                            </div>
                            <div class="Holder">
                                <asp:RadioButton ID="Subject2" runat="server" Text="Subject 2"/>
                            </div>
                            <div class="Holder">
                                <asp:RadioButton ID="Subject3" runat="server" Text="Subject 3"/>
                            </div>
                            <div class="Holder">
                                <asp:RadioButton ID="Subject4" runat="server" Text="Subject 4"/>
                            </div>
                            <div class="Holder">
                                <asp:RadioButton ID="Subject5" runat="server" Text="Subject 5"/>
                            </div>
                        </div>
                        <div class="Yearlvl">
                            <p> Year Level </p>
                            <div class="Holder">
                                <asp:RadioButton ID="FirstLVL" runat="server" Text="First Year" />
                            </div>
                            <div class="Holder">
                                <asp:RadioButton ID="SecondLVL" runat="server" Text="Second Year" />
                            </div>
                        </div>
                        <div class="Availability">
                            <p> Availability </p>
                            <div class="Holder">
                                <asp:CheckBox ID="Monday" runat="server" Text="Monday" value="Monday"/>
                            </div>
                            <div class="Holder">
                                <asp:CheckBox ID="Tuesday" runat="server" Text="Tuesday" value="Tuesday"/>
                            </div>
                            <div class="Holder">
                                <asp:CheckBox ID="Wednesday" runat="server" Text="Wednesday" value="Wednesday"/>
                            </div>
                            <div class="Holder">
                                <asp:CheckBox ID="Thursday" runat="server" Text="Thursday" value="Thursday"/>
                            </div>
                            <div class="Holder">
                                <asp:CheckBox ID="Friday" runat="server" Text="Friday" value="Friday"/>
                            </div>
                            <div class="Holder">
                                <asp:CheckBox ID="Saturday" runat="server" Text="Saturday" value="Saturday"/>
                            </div>
                            <div class="Holder">
                                <asp:CheckBox ID="Sunday" runat="server" Text="Sunday" value="Sunday"/>
                            </div>
                        </div>
                        <div class="Location">
                            <p> Location </p>
                            <div class="Holder">
                                <asp:CheckBox ID="Home" runat="server" Text="Home" value="Home"/>
                            </div>
                            <div class="Holder">
                                <asp:CheckBox ID="School" runat="server" Text="School" value="School"/>
                            </div>
                            <div class="Holder">
                                <asp:CheckBox ID="Other" runat="server" Text="Other Places" value="Other Places"/>
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
                            <p>TUTEE BULLETIN</p>
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
                                                <asp:Label ID="CardLooking" runat="server" Text='<%# Eval("looking") %>' class="label"></asp:Label>
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
        <!-- Hidden Div for Details -->
        <div id="detailsModal" class="HiddenDiv">
            <img src="../Images/PF_placeholder.png" />
            <br />
            <br />
            <label id="HiddenDivName"></label>
            <br />
            <label id="HiddenDivLooking"></label>
            <br />
            <label id="HiddenDivStrand"></label>
            <br />
            <label id="HiddenDivYearLevel"></label>
            <br />
            <label id="HiddenDivAvailability"></label>
            <br />
            <label id="HiddenDivLocation"></label>
            <br />
        </div>
        <!-- Bottom Layer for Bio -->
        <div class="BottomLayer">
            <label id="BioLabel"></label>
        </div>
        <script>
            function showDetails(rid) {
                // Fetch details and bio based on RID
                var details = fetchDetails(rid);
                var bio = fetchBio(rid);

                // Populate the hidden div
                document.getElementById("HiddenDivName").innerText = "Name: " + details.name;
                document.getElementById("HiddenDivLooking").innerText = "Looking For: " + details.looking;
                document.getElementById("HiddenDivStrand").innerText = "Strand: " + details.strand;
                document.getElementById("HiddenDivYearLevel").innerText = "Year Level: " + details.yearlevel;
                document.getElementById("HiddenDivAvailability").innerText = "Availability: " + details.availability;
                document.getElementById("HiddenDivLocation").innerText = "Location: " + details.location;

                // Show the hidden div
                document.getElementById("detailsModal").style.display = "block";
                document.getElementById("detailsModal").style.zIndex = "3"; // Bring to front

                // Show the BottomLayer
                document.getElementsByClassName("BottomLayer")[0].style.display = "block";

                // Populate bio in the BottomLayer
                document.getElementById("BioLabel").innerText = "Bio: " + bio;
            }

            function fetchDetails(rid) {
                // Implement your logic to fetch details from the server based on RID
                // This is a placeholder; replace it with your actual implementation
                return {
                    name: "John Doe",
                    looking: "Tutor",
                    strand: "STEM",
                    yearlevel: "First Year",
                    availability: "Monday, Wednesday",
                    location: "School"
                };
            }

            function fetchBio(rid) {
                // Implement your logic to fetch bio from the server based on RID
                // This is a placeholder; replace it with your actual implementation
                return "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            }

            function connectNow() {
                // Implement the logic for connecting now
                // You can use the details fetched earlier
                alert("Connect Now button clicked!");
            }
        </script>
    </form>
</body>
</html>