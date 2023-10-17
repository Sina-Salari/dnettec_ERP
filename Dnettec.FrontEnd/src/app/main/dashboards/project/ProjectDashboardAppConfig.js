import { lazy } from 'react';
import i18next from "i18next";
import fa from "./i18n/fa";

i18next.addResourceBundle("fa", "projectDashboard", fa);


const ProjectDashboardApp = lazy(() => import('./ProjectDashboardApp'));

const ProjectDashboardAppConfig = {
  settings: {
    layout: {
      config: {},
    },
  },
  routes: [
    {
      path: 'dashboards/project',
      element: <ProjectDashboardApp />,
    },
  ],
};

export default ProjectDashboardAppConfig;
