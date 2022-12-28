import { Box, Typography, Pagination } from "@mui/material";
import { MetaData } from "../models/pagination";

interface Props {
  metaData: MetaData;
  onChangePage: (page: number) => void;
}
export default function AppPagination({ metaData, onChangePage }: Props) {
  const { currentPage, totalCount, totalPage, pageSize } = metaData;
  return (
    <Box display='flex' justifyContent='space-between' alignItems='center'>
      <Typography>
        {(currentPage - 1) * pageSize + 1}დან- {currentPage * pageSize > totalCount ? totalCount : currentPage * pageSize}-მდე სულ {totalCount} პროდუქტი
      </Typography>
      <Pagination
        color='secondary'
        size='large'
        count={totalPage}
        page={currentPage}
        onChange={(e, page) => onChangePage(page)}
      />
    </Box>
  )
}