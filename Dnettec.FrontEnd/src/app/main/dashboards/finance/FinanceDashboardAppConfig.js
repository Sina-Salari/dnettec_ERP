import { lazy } from 'react';
import i18next from "i18next";
import fa from "./i18n/fa";

i18next.addResourceBundle("fa", "finaneDashboard", fa);


const FinanceDashboardApp = lazy(() => import('./FinanceDashboardApp'));

const FinanceDashboardAppConfig = {
  settings: {
    layout: {
      config: {},
    },
  },
  routes: [
    {
      path: 'dashboards/finance',
      element: <FinanceDashboardApp />,
    },
  ],
};

export default FinanceDashboardAppConfig;
