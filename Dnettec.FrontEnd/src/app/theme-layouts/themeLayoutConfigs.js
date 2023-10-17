import layout1 from "./layout1/Layout1Config";
import layout2 from "./layout2/Layout2Config";
import layout3 from "./layout3/Layout3Config";
import i18next from "i18next";
import fa from "./shared-components/i18n/fa";

i18next.addResourceBundle("fa", "sharedComponents", fa);

const themeLayoutConfigs = {
  layout1,
  layout2,
  layout3,
};

export default themeLayoutConfigs;
