import * as React from "react"

const style = require("./caption.style.scss");


export const CaptionComponent = () => (
  <div className={style.caption}>
    <p className={style.title}>Documents révélés.</p>
    <p className={style.subtitle}>Retrouvez facilement ce que vous cherchez.</p>
  </div>
);