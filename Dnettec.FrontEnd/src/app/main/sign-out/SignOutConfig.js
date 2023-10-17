import SignOutPage from './SignOutPage';
import i18next from "i18next";
import fa from "./i18n/fa";

i18next.addResourceBundle("fa", "signOutPage", fa);


const SignOutConfig = {
  settings: {
    layout: {
      config: {
        navbar: {
          display: false,
        },
        toolbar: {
          display: false,
        },
        footer: {
          display: false,
        },
        leftSidePanel: {
          display: false,
        },
        rightSidePanel: {
          display: false,
        },
      },
    },
  },
  auth: null,
  routes: [
    {
      path: 'sign-out',
      element: <SignOutPage />,
    },
  ],
};

export default SignOutConfig;
