import { lazy } from 'react';
import i18next from "i18next";
import fa from "./i18n/fa";

i18next.addResourceBundle("fa", "analyticsDashboard", fa);


const AnalyticsDashboardApp = lazy(() => import('./AnalyticsDashboardApp'));

const AnalyticsDashboardAppConfig = {
  settings: {
    layout: {
      config: {},
    },
  },
  routes: [
    {
      path: 'dashboards/analytics',
      element: <AnalyticsDashboardApp />,
    },
  ],
};

export default AnalyticsDashboardAppConfig;
