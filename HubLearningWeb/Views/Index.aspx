
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="HubLearningWeb.Views.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../Css/index.css" rel="stylesheet" />
<link rel="stylesheet" href="../bootstrapcss/bootstrap.minmat.css" />
	<link rel="icon" type="image/x-icon" href="../favicon-32x32.png" />
<title>Welcome!</title>
</head>
<body>
	<nav class="navbar navbar-expand-lg bg-body-tertiary">
  <div class="container-fluid">
    <a class="navbar-brand" href="Index.aspx">NOVALICHES HIGH SCHOOL</a>
      <form class="d-flex" action="Login.aspx">
        <button class="btn btn-secondary my-2 my-sm-0" type="submit">LOGIN</button>
      </form>
    </div>
</nav>


<div class="lorembigdiv">
	<div class="left">
		<h1 class="display-4">Novaliches High school</h1>
		<p>Novaliches High School is a public educational institution located in Quezon City that was founded in 1964. It offers education for junior and senior high school. The ABM, HUMSS, GAS, and STEM strands and the TVL track like ICT strand are offered for senior high school. The school is also recognized by the Department of Education (DepEd).</p>
	</div>
	<div class="right">
		<img class="right" src="/Images/NOVA.png" />
	</div>
</div>
<div class="row">

	<div class="col" >

		<div class ="ImgStrand"><img class="ImageStrand" src="../Images/STEM.png" /></div>
		<div><a href="#STEM">STEM</a></div>

	</div>
	<div class="col" >

		<div><img class="ImageStrand"  src="../Images/ABM.png" /></div>
		<div><a href="#ABM">ABM</a></div>

	</div>
	<div class="col" >

		<div><img class="ImageStrand" src="../Images/GAS.png" /></div>
		<div><a href="#GAS">GAS</a></div>

	</div>
	<div class="col">

		<div><img class="ImageStrand" src="../Images/HUM.png" />
	</div>
		<div><a href="#HUMS">HUMSS</a></div>

	</div>
	<div class="col" >

		<div><img class="ImageStrand" src="../Images/TV.png" /></div>
		<div><a href="#TV">TEC VOC</a></div>

	</div>
</div>
<hr />

<div class ="BIGSTRAND">
	<div class="Flexy">
		<div class="BSLoremFlex">
			<p class="Loremoments">The STEM stands for Science, Technology, Engineering, and Mathematics strand. This strand will help students become future scientists, technological analysts and experts, engineers, mathematicians, programmers, and the like by developing their ability to assess simple to complex societal problems and be responsive and active in the formulation of its solution through the application and integration of scientific, technological, engineering, and mathematical concepts. It also prepares them to pursue college degrees that center on the mystery of the natural world.</p>
			<div id="STEM">
			<div><img class="ImageStrandBig" src="../Images/STEM.png" /></div>
				<div class="AlignCen"><p>STEM</p></div>
			</div>
		</div>
		<div class="BSLoremFlex">
			<p class="Loremoments">The Accountancy, Business, and Management (ABM) track combines mathematical application, creativity, and business acumen to train tomorrow's top business leaders. Students will be introduced to the fundamentals of accounting, corporate operations, business management, and financial management when they take ABM classes in senior high school. This course will prepare students for exciting jobs as managers, accountants, and entrepreneurs. This course will prepare students for exciting jobs as managers, accountants, and entrepreneurs. With the knowledge and abilities gained from these ABM courses, they will be well-equipped to succeed in their careers and manage their enterprises.</p>
			<div id="ABM">
			<div><img class="ImageStrandBig" src="../Images/ABM.png" /></div>
				<div class="AlignCen"><p>ABM</p></div>
			</div>
		</div>
	</div>
	<div class="Flexy">
		<div class="BSLoremFlex">
			<p class="Loremoments">The Humanities and Social Sciences (HUMSS) strands provide students with a broad education by utilizing their experiences and abilities to investigate and inquire about human situations. They do this by utilizing empirical, analytical, and critical method techniques to study human behavior and social changes. Every student who takes HUMSS will get a greater grasp of politics, literature, the arts, culture, and society—how these variables' complexity is recognized during the urgent challenges that affect them.</p>
			<div>
				<div id="HUMS"><img class="ImageStrandBig" src="../Images/HUM.png" /></div>
				<div class="AlignCen"><p>HUMSS</p></div>
			</div>
		</div>
		<div class="BSLoremFlex">
			<p class="Loremoments">Information and communication technology (ICT) is transforming many sectors and organizations. Economic development is fueled by advancements in communication and technology, which are also transforming many facets of society. As a result, after obtaining their National Certification II from TESDA, the graduates of this strand will have the skills and abilities required for employment. Because of the department's extensive external network and wide range of industrial partners, graduates stand a good chance of finding employment because the firms will hire them for on-the-job training.</p>
			<div>
			<div id="TV"><img class="ImageStrandBig" src="../Images/TV.png" /></div>
			<div class="AlignCen"><p>TEC VOC</p></div>
			</div>
		</div>
	</div>
	<div class="Flexy">
		<div class="BSLoremFlex"> 
			<p class="Loremoments">The GAS strand is designed to accommodate students who would rather study a wide range of subjects than just one or two specializations. It gives SHS students the freedom to select electives from a variety of strands, assisting them in deciding on a university major. An introduction of this strand is given in this article, along with a list of courses students can enroll in to pave the way for future job success.</p>
			<div>
				<div id="GAS"><img class="ImageStrandBig" src="../Images/GAS.png" /></div>
				<div class="AlignCen"><p>GAS</p></div>
			</div>
		</div>
		<div class="BSLoremFlex"></div>
	</div>

</div>
</body>
</html>
