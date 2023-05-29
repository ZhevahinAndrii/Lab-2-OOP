﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="html"/>

    <xsl:template match="ElectronicArchive">
		<TABLE BORDER="4">
			<TR>
				<xsl:for-each select="speciality">
					<TR>
						<TD>
							<TABLE BORDER="1" WIDTH="1200">
								<TR>
									<th style="width:10%;">
										<p align="left">Course</p>
									</th>
									<th style =" width:90%;">
										<p align="left">
											<xsl:value-of select ="@COURSE" />
										</p>
									</th>
								</TR>
							</TABLE>
						</TD>
						<xsl:for-each select="group">
							<TR>
								<TD>
									<TABLE BORDER="5" WIDTH="1200">
										<TR>
											<th style="width: 10%;">
												<p align="left">Group</p>
											</th>
											<th style="width:90%;">
												<p align="left">
													<xsl:value-of select="@GROUP"/>
												</p>
											</th>
										</TR>
									</TABLE>
								</TD>
								<xsl:for-each select="student">
									<TR>
										<TD>
											<TABLE BORDER="5" WIDTH="1200">
												<TR>
													<th style="width:10%;">
														<p align="left">Auditory</p>
													</th>
													<th style="width:90%;">
														<p align="left">
															<xsl:value-of select="@AUDITORY"/>
														</p>
													</th>
												</TR>
												<TR>
													<th style="width:10%;">
														<p align="left">Surname</p>
													</th>
													<th style="width:90%;">
														<p align="left">
															<xsl:value-of select="@SURNAME"/>
														</p>
													</th>
												</TR>
												<TR>
													<th style="width:10%;">
														<p align="left">Name</p>
													</th>
													<th style="width:90%; ">
														<p align="left">
															<xsl:value-of select="@NAME"/>
														</p>
													</th>
												</TR>
												<TR>
													<th style="width: 10%; ">
														<p align="left">Phone number</p>
													</th>
													<th style="width:90%;">
														<p align="left">
															<xsl:value-of select="@AMOUNT"/>
														</p>
													</th>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</xsl:for-each>
							</TR>
						</xsl:for-each>
					</TR>
				</xsl:for-each>
			</TR>
		</TABLE>



	</xsl:template>
</xsl:stylesheet>
