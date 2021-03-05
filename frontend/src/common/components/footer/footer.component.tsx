import * as React from "react";
import { LogoMicrosoftComponent } from "../logo-microsoft";
import { cnc } from "../../../util";

const style = require("./footer.style.scss");

const Links = () => (
  <div className={style.linkArea}>
    <a className={style.link} href="https://technet.microsoft.com/en-US/cc300389.aspx" target="__blank">Termes et conditions d'utilisation</a>
    <a className={style.link} href="https://go.microsoft.com/fwlink/?LinkId=248681" target="__blank">Confidentialité</a>    
  </div>
);

const Statement = () => (
  <div className={style.statementArea}>
    © Futurafric IA 2021
  </div>
);

export const FooterComponent = ({className = null}) => {
  return (
    <footer className={cnc(style.footer, className)}>
      <Statement />
      <a href="https:\\www.futurafric.com" target="__blank">
        <LogoMicrosoftComponent colorful={false} classes={{container: style.logoContainer, svg: style.logoSvg }} />
      </a> 
      <Links />
    </footer>
  );
}