<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method='html' version='1.0' encoding='UTF-8' indent='yes' />
  <xsl:param name="documentuniqueid"></xsl:param>
  <xsl:param name="managementlevelstitle"></xsl:param>
  <xsl:param name="severitylevelstitle"></xsl:param>
  <xsl:param name="documentationlevelstitle"></xsl:param>
  <xsl:param name="onsetstitle"></xsl:param>
  <xsl:param name="placentaltransferstitle"></xsl:param>
  <xsl:param name="breastfeedingaapstitle"></xsl:param>
  <xsl:param name="breastfeedingratingstitle"></xsl:param>
  <xsl:param name="breastfeedingexcretedstitle"></xsl:param>
  <xsl:param name="alerttitle"></xsl:param>
  <xsl:param name="effecttitle"></xsl:param>
  <xsl:param name="mechanismtitle"></xsl:param>
  <xsl:param name="managementtitle"></xsl:param>
  <xsl:param name="discussiontitle"></xsl:param>
  <xsl:param name="commenttitle"></xsl:param>
  <xsl:param name="whattitle"></xsl:param>
  <xsl:param name="whytitle"></xsl:param>
  <xsl:param name="instructionstitle"></xsl:param>
  <xsl:param name="drugstitle"></xsl:param>
  <xsl:param name="referencestitle"></xsl:param>

  <xsl:template match="monograph">
    <xsl:if test="title">
      <h1>
        <xsl:value-of select="title" />
      </h1>
    </xsl:if>
    <xsl:if test="alert">
      <h3>
        <xsl:value-of select="$alerttitle" />
      </h3>
      <xsl:for-each select="alert/para">
        <p>
          <xsl:apply-templates select="." />
        </p>
      </xsl:for-each>
    </xsl:if>
    <xsl:if test="effect">
      <h3>
        <xsl:value-of select="$effecttitle" />
      </h3>
      <xsl:for-each select="effect/para">
        <p>
          <xsl:apply-templates select="." />
        </p>
      </xsl:for-each>
    </xsl:if>
    <xsl:if test="mechanism">
      <h3>
        <xsl:value-of select="$mechanismtitle" />
      </h3>
      <xsl:for-each select="mechanism/para">
        <p>
          <xsl:apply-templates select="." />
        </p>
      </xsl:for-each>
    </xsl:if>
    <xsl:if test="management">
      <h3>
        <xsl:value-of select="$managementtitle" />
      </h3>
      <xsl:for-each select="management/para">
        <p>
          <xsl:apply-templates select="." />
        </p>
      </xsl:for-each>
    </xsl:if>
    <xsl:if test="discussion">
      <h3>
        <xsl:value-of select="$discussiontitle" />
      </h3>
      <xsl:for-each select="discussion/para">
        <p>
          <xsl:apply-templates select="." />
        </p>
      </xsl:for-each>
    </xsl:if>
    <xsl:if test="comment">
      <h3>
        <xsl:value-of select="$commenttitle" />
      </h3>
      <xsl:for-each select="comment/para">
        <p>
          <xsl:apply-templates select="." />
        </p>
      </xsl:for-each>
    </xsl:if>
    <xsl:if test="what">
      <h3>
        <xsl:value-of select="$whattitle" />
      </h3>
      <xsl:for-each select="what/para">
        <p>
          <xsl:apply-templates select="." />
        </p>
      </xsl:for-each>
    </xsl:if>
    <xsl:if test="why">
      <h3>
        <xsl:value-of select="$whytitle" />
      </h3>
      <xsl:for-each select="why/para">
        <p>
          <xsl:apply-templates select="." />
        </p>
      </xsl:for-each>
    </xsl:if>
    <xsl:if test="instructions">
      <h3>
        <xsl:value-of select="$instructionstitle" />
      </h3>
      <xsl:for-each select="instructions/para">
        <p>
          <xsl:apply-templates select="." />
        </p>
      </xsl:for-each>
    </xsl:if>
    <xsl:if test="drugs">
      <h3>
        <xsl:value-of select="$drugstitle" />
      </h3>
      <xsl:for-each select="drugs/drug">
        <p>
          <xsl:apply-templates select="." />
        </p>
      </xsl:for-each>
    </xsl:if>
    <xsl:if test="references/reference">
      <h3 id="references">
        <xsl:value-of select="$referencestitle" />
      </h3>
      <p>
        <xsl:for-each select="references/reference">
          <xsl:choose>
            <xsl:when test="@id">
              <div id="{$documentuniqueid}_{@id}" class="rx-reference">
                <span class="rx-reference-index">
                  <xsl:value-of select="@id" />
                  <xsl:text>. </xsl:text>
                </span>
                <xsl:value-of select="." />
              </div>
            </xsl:when>
            <xsl:otherwise>
              <div class="rx-reference">
                <xsl:value-of select="." />
              </div>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:for-each>
      </p>
    </xsl:if>
    <xsl:if test="disclaimer">
      <hr />
      <div class="rx-footer">
        <div class="rx-disclaimer">
          <xsl:for-each select="disclaimer/para">
            <p>
              <xsl:apply-templates select="." />
            </p>
          </xsl:for-each>
        </div>
        <div class="rx-copyright">
          <xsl:for-each select="copyright/para">
            <p>
              <xsl:value-of select="." />
            </p>
          </xsl:for-each>
        </div>
      </div>
    </xsl:if>
  </xsl:template>

  <xsl:template match="drug">
    <strong>
      <xsl:value-of select="." />
    </strong>
  </xsl:template>

  <xsl:template match="referenceref">
    <span xml:space="preserve"> </span>
    <sup>
      <a class="rx-reference-link" href="#{$documentuniqueid}_{@id}">
        <xsl:value-of select="@id" />
      </a>
    </sup>
  </xsl:template>
</xsl:stylesheet>