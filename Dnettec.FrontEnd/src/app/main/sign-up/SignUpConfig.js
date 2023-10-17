import SignUpPage from './SignUpPage';
import authRoles from '../../auth/authRoles';
import i18next from "i18next";
import fa from "./i18n/fa";

i18next.addResourceBundle("fa", "signUpPage", fa);

const SignUpConfig = {
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
  auth: authRoles.onlyGuest,
  routes: [
    {
      path: 'sign-up',
      element: <SignUpPage />,
    },
  ],
};

export default SignUpConfig;
