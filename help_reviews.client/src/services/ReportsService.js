import { AppState } from "../AppState.js"
import { Report } from "../models/Report.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class ReportsService {

  async getReportsByRestaurantId(restaurantId) {
    const res = await api.get(`api/restaurants/${restaurantId}/reports`)
    logger.log('[GETTING REPORTS]', res.data)
    AppState.reports = res.data.map(r => new Report(r))
  }
}


export const reportsService = new ReportsService()